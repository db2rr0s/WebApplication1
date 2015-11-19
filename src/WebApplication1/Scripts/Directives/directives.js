(function () {
    'use strict';

    angular
        .module('directives', [])
        .directive('currencyformatter', currencyformatter);

    currencyformatter.$inject = ['$filter'];

    function currencyformatter($filter) {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ctrl) {
                ctrl.$formatters.push(function (data) {
                    var formatted = $filter('currency')(data);
                    return formatted;
                });
                ctrl.$parsers.push(function (data) {
                    var plainNumber = data.replace(/[^\d|\-+|\+]/g, '');
                    var length = plainNumber.length;
                    var intValue = plainNumber.substring(0, length - 2);
                    var decimalValue = plainNumber.substring(length - 2, length);
                    var plainNumberWithDecimal = intValue + '.' + decimalValue;
                    var formatted = $filter('currency')(plainNumberWithDecimal);
                    element.val(formatted);

                    return Number(plainNumberWithDecimal);
                });
            }
        };
    }

})();