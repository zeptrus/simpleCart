namespace Cart.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using AutoMapper;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;
    using Middleware;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile(path: $"appsettings.{env.EnvironmentName}.json", optional: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            return ConfigureServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //would not do this in a real application.
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                await next();
            });

            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseIISPlatformHandler();
            app.UseMvc();
        }

        private IServiceProvider ConfigureServiceProvider(IServiceCollection services)
        {
            var cartAssemblies = LoadReferencedAssemblies();
            var builder = new ContainerBuilder();
            builder.Register(c => this.Configuration).As<IConfiguration>().SingleInstance();
            builder.RegisterAssemblyModules(cartAssemblies.ToArray<Assembly>());
            builder.Populate(services);
            var container = builder.Build();

            ConfigureAutomapper(container);
            return container.Resolve<IServiceProvider>();
        }

        private List<Assembly> LoadReferencedAssemblies()
        {
            var assemblySet = new HashSet<Assembly>();
            LoadReferencedAssembliesRecursively(GetType().Assembly.GetName(), assemblySet);
            LoadReferencedAssembliesRecursively(Assembly.Load("Cart.Infrastructure").GetName(), assemblySet);
            return assemblySet.ToList();
        }

        private void LoadReferencedAssembliesRecursively(AssemblyName currentAssemblyName, HashSet<Assembly> assemblyList)
        {
            var currentAssembly = Assembly.Load(currentAssemblyName);

            if (assemblyList.Contains(currentAssembly))
            {
                return;
            }

            assemblyList.Add(currentAssembly);

            foreach (var assembly in currentAssembly.GetReferencedAssemblies()
                .Where(y => y.FullName.StartsWith("Cart")))
            {
                LoadReferencedAssembliesRecursively(assembly, assemblyList);
            }
        }


        private void ConfigureAutomapper(IContainer container)
        {
            var profiles = container.Resolve<IEnumerable<Profile>>();
            var config = new MapperConfiguration(cfg => {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            var newBuilder = new ContainerBuilder();
            newBuilder.Register(c => mapper).As<IMapper>().SingleInstance();
            newBuilder.Update(container);
        }
    }
}
