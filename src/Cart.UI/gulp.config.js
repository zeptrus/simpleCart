module.exports = function () {
    'use strict';

    var srcDir = './src/',
        app = srcDir + 'app/',
        temp = './.tmp/',
        typings = './typings/',
        config = {
            bower: {
                json: require('./bower.json'),
                directory: './bower_components',
                ignorePath: '../'
            },
            build: './dist/',
            client: srcDir,
            config: app + 'config.js',
            css: temp + 'styles.css',
            index: srcDir + 'index.html',
            js: [
                temp + '**/app.js',
                temp + '**/*.js',
                app + '**/*.js',
                '!' + app + 'config.js'
            ],
            temp: temp,
            templates: [
                srcDir + 'app/**/*.html',
                '!' + srcDir + 'index.html'
            ],
            tsBase: [
                app + 'app.module.ts',
                app + '*.ts',
                app + '**/*.ts',
                typings + '**/*.ts',
            ],
            sass: srcDir + 'styles/styles.scss'
        };

    config.getWiredepDefaultOptions = function () {
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
        };

        return options;
    };

    return config;
};
