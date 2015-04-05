'use strict';

app.factory('loginService',function($http, $location){
    return{
        login: function (data, scope) {
            data.ActivationKey = $location.search()['ActivationKey'];
            var userInfo = { name: data.name, password: data.password, activationKey: data.ActivationKey };
            var $promise = $http.post('api/Login', userInfo); //send data to user.php
            $promise.then(function(msg){
                var uid=msg.data;
                if(uid.name!=null){
                    UserId = uid.UserId;
                    scope.msgtxt = 'Success verifed';
                    $location.path('/order');
                }	       
                else  {
                    scope.msgtxt='incorrect information';
                    $location.path('/register');
                }				   
            });
            
        }
    }

});