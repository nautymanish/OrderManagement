


app.controller('ListCtrl', function ($scope, $location, orderFactory) {
    
    $scope.search = function () {
        orderFactory.getProducts($scope);
    };
    $scope.reset = function () {
        $scope.offset = 0;
        $scope.items = [];
        $scope.search();
    };

    $scope.items = [];
    $scope.showProducts = false;
    $scope.showBuy = true;
    $scope.orders = [];
    

    $scope.deleteOrder = function () {
        var itemId = this.item.TodoItemId;
       
    };

    $scope.addOrder = function (item) {
        $scope.showBuy = true;
    }

    $scope.placeOrder = function () {
       
        
        angular.forEach($scope.items, function (value, key) {
            var order =  { UserId: 1, quantity: value.quantity, productId: value.ProductId };
            $scope.orders.push(order);
        });
       
        orderFactory.submitOrder($scope);
    }

    $scope.showQuantity = function () { $scope.showBuy = false; }
    $scope.reset();
});



app.factory('orderFactory', function ($http, $location, $timeout) {
    return {
        getProducts: function ($scope) {
            var $promise = $http.get('api/Order', null); //send data to user.php
            $promise.then(function (msg) {
                var uid = msg.data;
                if (typeof (uid) != 'undefined') {

                    $scope.items = $scope.items.concat(msg.data);
                    $scope.showProducts = true;
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

        },

        submitOrder: function ($scope) {


            var $promise = $http.post('api/Order', $scope.orders); //send data to user.php
            $promise.then(function (msg) {
                var uid = msg.data;
                if (typeof (uid) != 'undefined') {

                    $scope.items = $scope.items.concat(msg.data);
                    $scope.showProducts = true;
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