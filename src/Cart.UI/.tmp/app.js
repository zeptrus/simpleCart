var app;
(function (app) {
    angular.module('templates', []);
    angular.module('app', [
        'templates',
        'ngRoute',
        'ui.bootstrap'
    ]);
    angular.element(document).ready(function () {
        var $injector = angular.injector(["app"]);
        angular.bootstrap(document, ["app"]);
    });
})(app || (app = {}));

(function () {
    'use strict';
    angular.module('app').constant('config', appConfig);
})();

var app;
(function (app) {
    var Route = (function () {
        function Route($routeProvider) {
            $routeProvider
                .when('/orders', { templateUrl: 'orders/ordersView.html' })
                .when('/customer/:customerId', { templateUrl: 'customer/customerView.html' })
                .otherwise({ templateUrl: 'orders/ordersView.html' });
        }
        return Route;
    }());
    angular.module('app').config(Route);
})(app || (app = {}));

var app;
(function (app) {
    var CustomerController = (function () {
        function CustomerController(CustomerService, OrderService, $routeParams) {
            var _this = this;
            CustomerService.getById($routeParams["customerId"]).then(function (customer) {
                _this.customer = customer;
                console.log(_this.customer);
                OrderService.searchOrders(_this.customer.Id).then(function (orders) {
                    _this.orders = orders;
                });
            });
        }
        return CustomerController;
    }());
    angular.module('app').controller('CustomerController', CustomerController);
})(app || (app = {}));



var app;
(function (app) {
    var Order = (function () {
        function Order() {
        }
        return Order;
    }());
    app.Order = Order;
})(app || (app = {}));

var app;
(function (app) {
    var OrderService = (function () {
        function OrderService($http, $q, config) {
            this.$http = $http;
            this.$q = $q;
            this.url = config.serviceUrl + "orders";
        }
        OrderService.prototype.searchOrders = function (customerId) {
            var query = "";
            if (customerId != null) {
                query += "?customerId=" + customerId;
            }
            return this.$http.get(this.url + query).then(function (response) {
                return response.data.map(OrderService.mapApiOrder);
            }, function (response) {
                return response.status;
            });
        };
        OrderService.mapApiOrder = function (apiData) {
            return {
                Id: apiData.Id,
                TotalPaid: apiData.TotalPaid,
                DatePlaced: new Date(apiData.DatePlaced),
                CustomerId: apiData.CustomerId
            };
        };
        return OrderService;
    }());
    app.OrderService = OrderService;
    angular.module("app").service("OrderService", OrderService);
})(app || (app = {}));

var app;
(function (app) {
    var OrdersController = (function () {
        function OrdersController(OrderService, CustomerService) {
            var _this = this;
            this.customerLookup = {};
            OrderService.searchOrders(null).then(function (data) {
                _this.orders = data;
            });
            CustomerService.getAll().then(function (data) {
                console.log(data);
            });
        }
        return OrdersController;
    }());
    angular.module('app').controller('OrdersController', OrdersController);
})(app || (app = {}));



var app;
(function (app) {
    var Customer = (function () {
        function Customer() {
        }
        return Customer;
    }());
    app.Customer = Customer;
})(app || (app = {}));

var app;
(function (app) {
    var CustomerService = (function () {
        function CustomerService(config, $http) {
            this.$http = $http;
            this.url = config.serviceUrl + "customers";
        }
        CustomerService.prototype.getAll = function (id) {
            return this.$http.get(this.url).then(function (response) {
                return response.data.map(CustomerService.mapApiCustomer);
            }, function (response) {
                return response.status;
            });
        };
        CustomerService.prototype.getById = function (id) {
            return this.$http.get(this.url + "/" + id).then(function (response) {
                return CustomerService.mapApiCustomer(response.data);
            }, function (response) {
                return response.status;
            });
        };
        CustomerService.mapApiCustomer = function (apiData) {
            return {
                Id: apiData.Id,
                FirstName: apiData.FirstName,
                LastName: apiData.LastName
            };
        };
        return CustomerService;
    }());
    app.CustomerService = CustomerService;
    angular.module("app").service("CustomerService", CustomerService);
})(app || (app = {}));
