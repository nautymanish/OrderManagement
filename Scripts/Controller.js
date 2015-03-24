var OrderApp = angular.module("OrderApp", ["ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            //when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            when('/', { controller: LoginCtrl, templateUrl: 'Views/Login.html' }).
            when('/new', { controller: CreateCtrl, templateUrl: 'detail.html' }).
            when('/edit/:itemId', { controller: EditCtrl, templateUrl: 'detail.html' }).
            otherwise({ redirectTo: '/' });
    });

OrderApp.factory('Order', function ($resource) {
    return $resource('/api/Order/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

OrderApp.factory('Login', function ($resource) {
    return $resource('/api/Login', { update: { method: 'PUT' } });
});

var ListCtrl = function ($scope, $location, Order) {
    
    $scope.search = function () {
        Order.query({
            q: $scope.query,
            limit: $scope.limit,
            offset: $scope.offset,
            sort: $scope.sort_order,
            desc: $scope.sort_desc
        },
            function (items) {
                var cnt = items.length;
                $scope.no_more = cnt < 20;
                $scope.items = $scope.items.concat(items);
            }
        );
    };

    $scope.reset = function () {
        $scope.offset = 0;
        $scope.items = [];
        $scope.search();
    };

    $scope.show_more = function () { return !$scope.no_more; };

    $scope.sort_by = function (ord) {
        if ($scope.sort_order == ord) { $scope.sort_desc = !$scope.sort_desc; }
        else { $scope.sort_desc = false; }
        $scope.sort_order = ord;
        $scope.reset();
    };

    $scope.delete = function () {
        var itemId = this.item.OrderItemId;
        Order.delete({ id: itemId }, function () {
            $("#item_" + itemId).fadeOut();
        });
    };


    $scope.limit = 20;
    $scope.sort_order = 'Priority';
    $scope.sort_desc = false;

    $scope.reset();
};

var CreateCtrl = function ($scope, $location, Order) {
    $scope.btnName = "Add";

    $scope.save = function () {
        Order.save($scope.item, function () {
            $location.path('/');
        });
    };
};

var EditCtrl = function ($scope, $routeParams, $location, Order) {
    $scope.item = Order.get({ id: $routeParams.itemId });
    $scope.btnName = "Edit";

    $scope.save = function () {
        Order.update({ id: $scope.item.OrderItemId }, $scope.item, function () {
            $location.path('/');
        });
    };
};


OrderApp.directive('sorted', function () {
    return {
        scope: true,
        transclude: true,
        template: '<a ng-click="do_sort()" ng-transclude></a>' +
            '<span ng-show="do_show(true)"><i class="icon-circle-arrow-down"></i></span>' +
            '<span ng-show="do_show(false)"><i class="icon-circle-arrow-up"></i></span>',

        controller: function ($scope, $element, $attrs) {
            $scope.sort = $attrs.sorted;

            $scope.do_sort = function () { $scope.sort_by($scope.sort); };

            $scope.do_show = function (asc) {
                return (asc != $scope.sort_desc) && ($scope.sort_order == $scope.sort);
            };
        }
    };
});


var LoginCtrl = function ($scope, $location, Order) {
    
    $scope.login = function () {
        debugger;
        var loginUserName = this.login.userName;
        var pwd = this.login.passWord;

        Login.get();

        Order.delete({ id: itemId }, function () {
            $("#item_" + itemId).fadeOut();
        });
    };


   $scope.loginBtnName = "Login User";
};
