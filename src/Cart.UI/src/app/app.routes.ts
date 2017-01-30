module app {

    class Route {

        constructor($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when('/orders', { templateUrl: 'orders/ordersView.html' })
                .when('/customer/:customerId', { templateUrl: 'customer/customerView.html' })
                .otherwise({ templateUrl: 'orders/ordersView.html' });
        }
    }

    angular.module('app').config(Route);
}