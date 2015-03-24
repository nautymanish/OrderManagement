'use strict';

app.controller('loginCtrl', function ($scope, loginService) {
    $scope.msgtxt = 'Enter Credentials';
    $scope.login = function (user) {
        loginService.login(user, $scope);
  };
});