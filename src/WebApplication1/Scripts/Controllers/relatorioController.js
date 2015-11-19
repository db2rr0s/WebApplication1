(function () {
    'use strict';

    angular
        .module('WebApplication1')
        .controller('relatorioController', relatorioController);

    relatorioController.$inject = ['$scope', 'Relatorio'];

    function relatorioController($scope, Relatorio) {
        $scope.filter = {
            StartDate: undefined,
            EndDate: undefined,
            ApplyGroup: false
        };

        $scope.search = function () {
            if ($scope.filter.ApplyGroup) {
                $scope.items2 = Relatorio.query($scope.filter);
                
            } else {
                $scope.items = Relatorio.query($scope.filter);
            }
        };

        $scope.export = function () {            
        };
    }
})();
