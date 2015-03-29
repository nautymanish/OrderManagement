'use strict';

app.factory('loginService',function($http, $location){
    return{
        login:function(data,scope){
            var $promise=$http.post('api/Login',data); //send data to user.php
            $promise.then(function(msg){
                var uid=msg.data;
                if(uid.name!=null){
                    
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