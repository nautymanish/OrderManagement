'use strict';

app.controller('registerCtrl', function ($scope, registerService) {
    $scope.msgtxt = 'Mail had been sent to your email, please verify to continue further';
    $scope.showMessage = false;
    $scope.register = function (user) {
        var userEntry = { name: user.UserName, password: user.password };
        registerService.register(userEntry, $scope);
  };
});

