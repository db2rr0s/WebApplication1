(function () {
    'use strict';

    angular
        .module('WebApplication1')
        .controller('homeController', homeController);

    homeController.$inject = ['$scope']; 

    function homeController($scope) {}
})();
