'use strict';

// the storeController contains two objects:
// - store: contains the product list
// - cart: the shopping cart object
function storeController($scope, $routeParams,$http, DataService) {

    // get store and cart from service
    $scope.store = DataService.store;
    $scope.cart = DataService.cart;
    DataService.getProducts($http,$scope);
    // use routing to pick the selected product
    if ($routeParams.productSku != null) {
        $scope.product = $scope.store.getProduct($routeParams.productSku);
    }
}

app.factory("DataService", function () {


    // create store
    var myStore = new store();

    // create shopping cart
    var myCart = new shoppingCart("AngularStore");

   return {
        store: myStore,
        cart: myCart,
        getProducts: function ($http, $scope) {
            if ($scope.store.products.length == 0) {
                var $promise = $http.get('api/Order', null); //send data to user.php
                $promise.then(function (msg) {
                    var uid = msg.data;
                    if (typeof (uid) != 'undefined') {

                        $.each(uid, function (idx, obj) {
                            $scope.store.products.push(new product(obj.ProductId, obj.ProductName, obj.ProductName, obj.ProductPrice));
                        });

                    }

                }).catch(function (msg) {
                    if (msg.status == 501) {
                        $scope.msgtxt = msg.data;

                    }
                    else {
                        $scope.msgtxt = ('Oops !! something went wrong while registering. Contact xx@support.com');
                    }

                });
            }

        }
    };
});
