'use strict';

app.factory('registerService', function ($http, $location, $timeout) {
    return{
        register:function(data,$scope){
            var $promise=$http.post('api/Register',data); //send data to user.php
            $promise.then(function(msg){
                var uid=msg.data;
                if(uid){
                                    
                    $scope.showMessage = true;
                    $timeout(function () { $location.path('/'); }, 100);
                   
                }	       
                else  {
                    $scope.msgtxt = 'Oops !! something went wrong while registering. Contact xx@support.com';
                    $scope.showMessage = true;
                }				   
            }).catch(function (msg) {
                if (msg.status == 501) {
                    $scope.msgtxt = msg.data;
                    
                }
                else {
                    $scope.msgtxt = ('Oops !! something went wrong while registering. Contact xx@support.com');
                }
                $scope.showMessage = true;
            });
            
        }
    }

});