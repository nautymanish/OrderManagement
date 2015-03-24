'use strict';

app.controller('registerCtrl', function ($scope, $registerService) {
    $scope.msgtxt = 'Mail had been sent to your email, please verify to continue further';
    $scope.showMessage = false;
    $scope.register = function (user) {
        $registerService.register(user, $scope);
    };
});

