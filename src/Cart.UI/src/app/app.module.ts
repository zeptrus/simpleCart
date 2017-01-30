module app {
    angular.module('templates', []);

    angular.module('app', [
        'templates',
        'ngRoute',
        'ui.bootstrap'
    ]);

    angular.element(document).ready(() => {
        var $injector = angular.injector(["app"]);
        angular.bootstrap(document, ["app"]);
    });
}
