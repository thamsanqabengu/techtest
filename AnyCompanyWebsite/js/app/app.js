angular.module('currencyMask', []).directive('currencyMask', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelController) {
            // Run formatting on keyup
            var numberWithCommas = function (value, addExtraZero) {
                if (addExtraZero === undefined)
                    addExtraZero = false;
                value = value.toString();
                value = value.replace(/[^0-9\.]/g, "");
                var parts = value.split('.');
                parts[0] = parts[0].replace(/\d{1,3}(?=(\d{3})+(?!\d))/g, "$&,");
                if (parts[1] && parts[1].length > 2) {
                    parts[1] = parts[1].substring(0, 2);
                }
                if (addExtraZero && parts[1] && (parts[1].length === 1)) {
                    parts[1] = parts[1] + "0";
                }
                return parts.join(".");
            };
            var applyFormatting = function () {
                var value = element.val();
                var original = value;
                if (!value || value.length === 0) {
                    return;
                }
                value = numberWithCommas(value);
                if (value !== original) {
                    element.val(value);
                    element.triggerHandler('input');
                }
            };
            element.bind('keyup', function (e) {
                var keycode = e.keyCode;
                var isTextInputKey =
                    (keycode > 47 && keycode < 58) || // number keys
                    keycode === 32 || keycode === 8 || // spacebar or backspace
                    (keycode > 64 && keycode < 91) || // letter keys
                    (keycode > 95 && keycode < 112) || // numpad keys
                    (keycode > 185 && keycode < 193) || // ;=,-./` (in order)
                    (keycode > 218 && keycode < 223); // [\]' (in order)
                if (isTextInputKey) {
                    applyFormatting();
                }
            });
            ngModelController.$parsers.push(function (value) {
                if (!value || value.length === 0) {
                    return value;
                }
                value = value.toString();
                value = value.replace(/[^0-9\.]/g, "");
                return value;
            });
            ngModelController.$formatters.push(function (value) {
                if (!value || value.length === 0) {
                    return value;
                }
                value = numberWithCommas(value, true);
                return value;
            });
        }
    };
});
(function () {
    'use strict';

    //var webservicebaseurl = 'http://localhost:50306/';

    var tjcApp = angular.module('app', ['720kb.datepicker', 'currencyMask', 'bsLoadingOverlay', 'bsLoadingOverlayHttpInterceptor'

    ]).factory('allHttpInterceptor', function (bsLoadingOverlayHttpInterceptorFactoryFactory) {
        return bsLoadingOverlayHttpInterceptorFactoryFactory();
    }).config(function ($httpProvider) {
            $httpProvider.interceptors.push('allHttpInterceptor');
        }, ['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            //$urlRouterProvider.when('/dashboard', '/dashboard/overview');
            //$urlRouterProvider.otherwise('/dashboard/overview');

            //$routeProvider.when('/cv', { controller: 'cvctrl', templateUrl: 'cv/index.html' });
            //$routeProvider.otherwise('/');

            $locationProvider.html5Mode(true);

        }]).run(function (bsLoadingOverlayService) {
        bsLoadingOverlayService.setGlobalConfig({
            delay: 0, // Minimal delay to hide loading overlay in ms.
            activeClass: undefined, // Class that is added to the element where bs-loading-overlay is applied when the overlay is active.
            templateUrl: 'template.html' // Template url for overlay element. If not specified - no overlay element is created.

        });
        });


    tjcApp.value('_websitebaseurl', 'http://localhost/anycompanywebsite');
    tjcApp.value('_webservicebaseurl', 'http://localhost/anycompanywebsitewebapi');

    var currenturl = location.pathname;
    var baseurl = 'http://localhost/anycompanywebsite/';
    tjcApp.value('_redirecturl');

})();