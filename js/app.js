﻿
'use strict'
var UserId = '';
var app = angular.module('orderApp', ['ngRoute', 'UserValidation']);
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'Views/Login.html', controller: 'loginCtrl' });
    $routeProvider.when('/register', { templateUrl: 'Views/register.html', controller: 'registerCtrl' });
    $routeProvider.when('/store', { templateUrl: 'Views/list.html', controller: 'ListCtrl' });
    $routeProvider.when('/order', {
        templateUrl: 'Views/store.htm',
        controller: storeController
    });      
    $routeProvider.when('/cart', {
        templateUrl: 'Views/shoppingCart.htm',
        controller: storeController
    });
    $routeProvider.otherwise({ redirectTo: '/' });
}]);

//password validator
angular.module('UserValidation', []).directive('validPasswordC', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$parsers.unshift(function (viewValue, $scope) {

                var noMatch = viewValue != scope.registerUser.password.$viewValue
                ctrl.$setValidity('noMatch', !noMatch)
            })
        }
    }
})