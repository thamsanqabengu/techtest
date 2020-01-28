(function () {
    'use strict';

    angular
        .module('app')
        .controller('orders', orders);

    orders.$inject = ['$http', '$location', '$window', '_websitebaseurl', '_webservicebaseurl', '_username', '_isloggedin'];

    function orders($http, $location, $window, _websitebaseurl, _webservicebaseurl, _username, _isloggedin) {
        var vm = this;
        vm.urls = {};
        vm.urls.weburl = _websitebaseurl;
        vm.urls.webserviceurl = _webservicebaseurl;

        vm.OrdersList = {};

        vm.OrderObjects = {};
        vm.OrderObjects._customer = {};
        vm.OrderObjects._menu = {};
        vm.OrderObjects._orders = {};
        vm.OrderObjects._orderMessages = {};
        
        vm.ViewOrderEntry = false;

        vm.messages = [];
        vm.errors = [];
        vm.pagefunction = {};

        vm.cancelOrderEntry = function () {
            vm.ViewOrderEntry = false;
            vm.OrderEntry = [];
            window.location.href = vm.urls.weburl;
        };

        vm.selectOrderEntry = function (index) {
            vm.ViewOrderEntry = true;
            vm.OrderEntry = vm.OrdersList[index];
            document.getElementById("entryname").focus();
        };

        function selectOrderEntry(index) {
            vm.ViewOrderEntry = true;
            vm.OrderEntry = vm.OrdersList[index];
        }

        vm.addOrderEntry = function () {
            vm.ViewOrderEntry = true;
            vm.selectedOrderEntry = {};
            vm.OrderEntry = {};
        };

        vm.deleteOrderEntry = function (_orderId) {
            _deleteOrderEntry(_orderId).then(function (results) {
                if (results.statusText === "OK" && results.status === 200 && results.data._isOrderEntryDeleted) {
                    vm.messages = "Order Entry deleted successfully";
                }
                vm.cancelOrderEntry();
            });
        };

        vm.saveAll = function () {

            if (vm.OrderEntry !== undefined || vm.OrderEntry !== null) {
                if (vm.OrderEntry.PhonebookEntryId === undefined) {
                    vm.OrderEntry.PhonebookId = 0;
                    vm.OrderEntry.PhonebookEntryId = 0;
                    vm.OrderEntry.PhonebookContactName = vm.OrderEntry.EntryName;
                    vm.OrdersList.push(vm.OrderEntry);
                }
            }

            if (vm.OrdersList === null) {
                vm.PageError.Message = 'Please check the entry.';
                return;
            }
            else {

                vm.OrdersObjects._orders = vm.OrdersList;
            }

            _saveAll(vm.OrderEntry).then(function (results) {

                vm.cancelOrderEntry();

            }, function (error) {

                vm.error = error;
                vm.ViewOrderEntry = false;

            });
        };

        vm.getOrders = function () {

            vm.OrdersList = {};
            vm.PageError = [];

            _getOrders().then(function (results) {

                vm.OrdersList = results.data._orders;
                vm.PageError = results.data._orderMessages;
                
            }, function (error) {

                vm.PageError = error;

            });
        };

        var _saveAll = function (objdata) {
            var currurl = vm.urls.webserviceurl + '/orders/ordermodify/';
            return $http({
                url: currurl,
                data: objdata,
                method: "POST"
            }).then(function (results) {
                return results;
            });
        };

        var _getOrders = function () {
            var currurl = vm.urls.webserviceurl + '/orders/';
            return $http({
                url: currurl,
                method: "GET"
            }).then(function (results) {
                return results;
            });
        };

        vm.getOrders();

        function getUrlParameter(name) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(location.search);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        }

    }
})();
