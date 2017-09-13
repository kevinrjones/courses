var app = angular.module("app", ["ngRoute", "ngResource"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: '/template/lists.html',
            controller: 'ListsController'
        }).when("/list/:id", {
            templateUrl: '/template/list.html',
            controller: 'ListController'
        })

});

app.service("ListService", ["ListResource", function (List) {

    var data = [
        {
            id: 1,
            title: "Todo",
            activities: [
                {
                    name: "Finish chapter",
                    priority: 3
                },
                {
                    name: "Do lab",
                    priority: 2
                },
                {
                    name: "Watch football",
                    priority: 5
                }
            ]
        },
        {
            id: 2,
            title: "Project X"
        }
    ];

    this.getLists = function () {
        //return $http.get('/api/list');
        return List.query();
    };

    this.save = function (list) {

    };

    this.getList = function (id) {
        return List.get({id: id});
    }
}]);

app.controller("ListsController", ["$scope", "ListService", "$location", function ($scope, ListService, $location) {

    $scope.lists = ListService.getLists();

    $scope.openList = function (id) {
        $location.path("/list/" + id);
    };

}]);

app.factory("ListResource", function ($resource) {
    return $resource('/api/list/:id', {
        id: '@id'
    }, {
        save: {
            method: 'PUT'
        }
    });
});


app.controller("ListController", ["$scope", "ListService", "$routeParams", "$location", function ($scope, ListService, $routeParams, $location) {

    setInterval(function () {
        $scope.$apply(function () {
            $scope.currentTime = new Date().toLocaleTimeString();
        })
    }, 1000);

    $scope.currentDate = new Date();
    $scope.currentTime = new Date().toLocaleTimeString();
    $scope.list = ListService.getList($routeParams.id);
}]);

app.directive("kjSimple", function () {
    return {
        restrict: "EA",
        replace: false,
        template: "<div ng-click='sayHello()'>Hello <span ng-transclude></span></div>",
        transclude: true,
        link: function (scope) {
            scope.sayHello = function () {
                //alert('Hello');
            }
        }
    }
});

app.directive("kjDouble", function () {
    return {
        restrict: "E",
        scope: {
            value: "@"
        },
        template: '<div>{{result}}</div>',
        link: function (scope) {
            var n = +scope.value;
            scope.result = n * 2;
        }
    }
});

app.directive("kjLists", function () {
    return{
        restrict: "E",
        scope: {
            title: "@",
            lists: "=",
            open: "&"
        },
        template: "<h2>{{ title }}</h2>" +
            "<ul>" +
            "            <li ng-repeat='list in lists'>" +
            "            <span ng-click='open({id: list.id})'>{{ list.title }}</span>" +
            "            </li>" +
            "    </ul>",
        link: function (scope) {
//            scope.openList = function(id){
//                scope.$parent.openList(id);
//            }
        }
    }
});

app.directive("kjBad", function(){
   return {
       restrict: "E",
       template: '<div><input type="text" ng-model="person.name"/></div>',
       scope: true
   }
});

app.controller("badController", function($scope){
    $scope.person = {
        name: ""
    }
});

















