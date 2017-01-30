var app;!function(t){angular.module("templates",[]),angular.module("app",["templates","ngRoute","ui.bootstrap"]),angular.element(document).ready(function(){angular.injector(["app"]);angular.bootstrap(document,["app"])})}(app||(app={})),function(){"use strict";angular.module("app").constant("config",appConfig)}();var app;!function(t){var r=function(){function t(t){t.when("/orders",{templateUrl:"orders/ordersView.html"}).when("/customer/:customerId",{templateUrl:"customer/customerView.html"}).otherwise({templateUrl:"orders/ordersView.html"})}return t.$inject=["$routeProvider"],t}();angular.module("app").config(r)}(app||(app={}));var app;!function(t){var r=function(){function t(t,r,e){var n=this;t.getById(e.customerId).then(function(t){n.customer=t,console.log(n.customer),r.searchOrders(n.customer.Id).then(function(t){n.orders=t})})}return t.$inject=["CustomerService","OrderService","$routeParams"],t}();angular.module("app").controller("CustomerController",r)}(app||(app={}));var app;!function(t){var r=function(){function t(){}return t}();t.Order=r}(app||(app={}));var app;!function(t){var r=function(){function t(t,r,e){this.$http=t,this.$q=r,this.url=e.serviceUrl+"orders"}return t.$inject=["$http","$q","config"],t.prototype.searchOrders=function(r){var e="";return null!=r&&(e+="?customerId="+r),this.$http.get(this.url+e).then(function(r){return r.data.map(t.mapApiOrder)},function(t){return t.status})},t.mapApiOrder=function(t){return{Id:t.Id,TotalPaid:t.TotalPaid,DatePlaced:new Date(t.DatePlaced),CustomerId:t.CustomerId}},t}();t.OrderService=r,angular.module("app").service("OrderService",r)}(app||(app={}));var app;!function(t){var r=function(){function t(t,r){var e=this;this.customerLookup={},t.searchOrders(null).then(function(t){e.orders=t}),r.getAll().then(function(t){console.log(t)})}return t.$inject=["OrderService","CustomerService"],t}();angular.module("app").controller("OrdersController",r)}(app||(app={}));var app;!function(t){var r=function(){function t(){}return t}();t.Customer=r}(app||(app={}));var app;!function(t){var r=function(){function t(t,r){this.$http=r,this.url=t.serviceUrl+"customers"}return t.$inject=["config","$http"],t.prototype.getAll=function(r){return this.$http.get(this.url).then(function(r){return r.data.map(t.mapApiCustomer)},function(t){return t.status})},t.prototype.getById=function(r){return this.$http.get(this.url+"/"+r).then(function(r){return t.mapApiCustomer(r.data)},function(t){return t.status})},t.mapApiCustomer=function(t){return{Id:t.Id,FirstName:t.FirstName,LastName:t.LastName}},t}();t.CustomerService=r,angular.module("app").service("CustomerService",r)}(app||(app={})),angular.module("templates").run(["$templateCache",function(t){t.put("orders/ordersView.html",'<div ng-controller="OrdersController as vm"><table><tr><th>Id</th><th>Total</th><th>Date</th><th>Customer</th></tr><tr ng-repeat="order in vm.orders"><td>{{order.Id}}</td><td>{{order.TotalPaid | currency}}</td><td>{{order.DatePlaced | date:\'MMM d, y\'}}</td><td><a href=#/customer/{{order.CustomerId}}>Customer Information</a></td></tr></table></div>'),t.put("customer/customerView.html",'<div ng-controller="CustomerController as vm"><a href=#/orders>< Back to Orders</a><h2>Orders for {{vm.customer.FirstName + " " + vm.customer.LastName}}</h2><section><table><tr><th>Id</th><th>Total</th><th>Date</th></tr><tr ng-repeat="order in vm.orders"><td>{{order.Id}}</td><td>{{order.TotalPaid | currency}}</td><td>{{order.DatePlaced | date:\'MMM d, y\'}}</td></tr></table></section></div>')}]);