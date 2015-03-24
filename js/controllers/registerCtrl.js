'use strict';

app.controller('registerCtrl', function ($scope) {
    $scope.msgtxt = 'Mail had been sent to your email, please verify to continue further';
    $scope.showMessage = false;
    $scope.register = function (user) {
        alert('Manish');
    };
});

