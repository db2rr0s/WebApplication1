(function () {
    'use strict';

    angular
        .module('WebApplication1')
        .controller('receitaIndexController', receitaIndexController)
        .controller('receitaCreateController', receitaCreateController)
        .controller('receitaEditController', receitaEditController)
        .controller('receitaDeleteController', receitaDeleteController);

    receitaIndexController.$inject = ['$scope', 'Receita'];

    function receitaIndexController($scope, Receita) {
        $scope.filter = {
            StartDate: undefined,
            EndDate: undefined,
            Category: undefined
        };

        $scope.search = function () {
            $scope.receitas = Receita.query($scope.filter);
        }

        $scope.search();
    }

    receitaCreateController.$inject = ['$scope', '$location', 'Receita'];

    function receitaCreateController($scope, $location, Receita) {
        $scope.receita = new Receita();

        $scope.create = function () {
            $scope.receita.$save(
				function () {
				    $location.path('/Receitas');
				},
				function (error) {
				    showValidationErrors($scope, error);
				}
			);
        };
    }

    receitaEditController.$inject = ['$scope', '$routeParams', '$location', 'Receita'];

    function receitaEditController($scope, $routeParams, $location, Receita) {
        $scope.receita = Receita.get({ id: $routeParams.id });
        $scope.edit = function () {
            $scope.receita.$save(
				function () {
				    $location.path('/Receitas');
				},
				function (error) {
				    showValidationErrors($scope, error);
				}
			);
        };
    }

    receitaDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Receita'];

    function receitaDeleteController($scope, $routeParams, $location, Receita) {
        $scope.receita = Receita.get({ id: $routeParams.id });
        $scope.delete = function () {
            $scope.receita.$delete({ id: $routeParams.id }, function () {
                $location.path('/Despesas');
            });
        };
    }

    function showValidationErrors($scope, error) {
        $scope.validationErrors = [];
        if (error.data && angular.isObject(error.data)) {
            for (var key in error.data) {
                $scope.validationErrors.push("Campo " + key + ": " + error.data[key][0]);
            }
        } else {
            $scope.validationErrors.push('Ocorreu um erro na execução.');
        };
    }
})();
