'use strict';

app.factory('registerService',function($http, $location){
    return{
        register:function(data,scope){
            var $promise=$http.post('api/Register',data); //send data to user.php
            $promise.then(function(msg){
                var uid=msg.data;
                if(uid){
                    
                    scope.msgtxt = 'Success verifed';
                    $location.path('/home');
                }	       
                else  {
                    scope.msgtxt='incorrect information';
                    $location.path('/register');
                }				   
            });
            
        }
    }

});