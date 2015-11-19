(function () {
    'use strict';

    angular
        .module('services', ['ngResource'])
        .factory('Despesa', Despesa)
        .factory('Receita', Receita)
        .factory('Relatorio', Relatorio);

    Despesa.$inject = ['$resource'];

    function Despesa($resource) {
        return $resource('/api/despesa/:id', null, { 'update': { method: 'PUT' } });
    }

    Receita.$inject = ['$resource'];

    function Receita($resource) {
        return $resource('/api/receita/:id', null, { 'update': { method: 'PUT' } });
    }

    Relatorio.$inject = ['$resource'];

    function Relatorio($resource) {
        return $resource('/api/relatorio');
    }
})();
