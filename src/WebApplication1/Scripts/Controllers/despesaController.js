(function () {
    'use strict';

    angular
        .module('WebApplication1')
        .controller('despesaIndexController', despesaIndexController)
        .controller('despesaCreateController', despesaCreateController)
        .controller('despesaEditController', despesaEditController)
        .controller('despesaDeleteController', despesaDeleteController);

    despesaIndexController.$inject = ['$scope', 'Despesa'];

    function despesaIndexController($scope, Despesa) {
        $scope.filter = {
            StartDate: undefined,
            EndDate: undefined,
            Category: undefined
        };

        $scope.search = function () {
            $scope.despesas = Despesa.query($scope.filter);
        }

        $scope.search();
    }

    despesaCreateController.$inject = ['$scope', '$location', 'Despesa'];

    function despesaCreateController($scope, $location, Despesa) {
        $scope.despesa = new Despesa();

        $scope.create = function () {
            $scope.despesa.$save(				
				function () {
				    $location.path('/Despesas');
				},				
				function (error) {
				    showValidationErrors($scope, error);
				}
			);
        };
    }

    despesaEditController.$inject = ['$scope', '$routeParams', '$location', 'Despesa'];

    function despesaEditController($scope, $routeParams, $location, Despesa) {
        $scope.despesa = Despesa.get({ id: $routeParams.id });
        $scope.edit = function () {
            $scope.despesa.$save(				
				function () {
				    $location.path('/Despesas');
				},				
				function (error) {
				    showValidationErrors($scope, error);
				}
			);
        };
    }

    despesaDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Despesa'];

    function despesaDeleteController($scope, $routeParams, $location, Despesa) {
        $scope.despesa = Despesa.get({ id: $routeParams.id });
        $scope.delete = function () {
            $scope.despesa.$delete({ id: $routeParams.id }, function () {
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
