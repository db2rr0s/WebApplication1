(function () {
    'use strict';

    angular.module('WebApplication1', ['ngRoute', 'services', 'directives', 'ui.mask'])

    .config(function ($routeProvider) {

        $routeProvider
            .when('/', {
                templateUrl: 'Home/Start',
                controller: 'homeController'
            })
            .when('/Despesas', {
                templateUrl: 'Despesa/Index',
                controller: 'despesaIndexController'
            })
            .when('/Despesa/Create', {
                templateUrl: 'Despesa/Create',
                controller: 'despesaCreateController'
            })
            .when('/Despesa/Edit/:id', {
                templateUrl: 'Despesa/Edit',
                controller: 'despesaEditController'
            })
            .when('/Despesa/Delete/:id', {
                templateUrl: 'Despesa/Delete',
                controller: 'despesaDeleteController'
            })
            .when('/Receitas', {
                templateUrl: 'Receita/Index',
                controller: 'receitaIndexController'
            })
            .when('/Receita/Create', {
                templateUrl: 'Receita/Create',
                controller: 'receitaCreateController'
            })
            .when('/Receita/Edit/:id', {
                templateUrl: 'Receita/Edit',
                controller: 'receitaEditController'
            })
            .when('/Receita/Delete/:id', {
                templateUrl: 'Receita/Delete',
                controller: 'receitaDeleteController'
            })
            .when('/Relatorio', {
                templateUrl: 'Relatorio/Index',
                controller: 'relatorioController'
            })
            .otherwise({
                redirectTo: '/'
            });
    });
})();
