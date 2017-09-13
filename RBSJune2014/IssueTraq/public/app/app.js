var services = angular.module("services", []);

var app = angular.module("app", ["services", "ngRoute", "ngResource"]);

app.controller("issuesController", ["issueService", "$location", function (issueService, $location) {


    var vm = this;

    vm.typeFilter = 0;
    vm.typeFilterValue = 0;
    vm.issues = [];

    vm.filter = function () {
        vm.typeFilterValue = vm.typeFilter;
    };


    issueService.getIssues().then(function (data) {
        vm.issues = data.issues;
    });

    vm.edit = function (id) {
        $location.path("/issue/edit/" + id);
    };

    vm.open = function (id) {
        $location.path("/issue/" + id);
    };

}]);

app.controller("issueController", ["issueService", "$location", "$routeParams", function (issueService, $location, $routeParams) {

    var vm = this;
    vm.issue = issueService.getIssue($routeParams["id"]);

    vm.update = function () {
        console.log(vm.issue);
    };

}]);

app.directive("issuesTitle", function () {
    return {
        restrict: "E",
        template: "<h2>Issues</h2>"
    }
});

app.directive("issueDetails", function () {
    return {
        restrict: 'E',
        scope: {issue: "="},
        transclude: true,
        compile: function () {
            console.log('compile');
            return function (scope, elem, attr) {
                console.log('linking');
                scope.isHidden = false;
                scope.openClose = function () {
                    scope.isHidden = !scope.isHidden;
                };
            }
        },
        template: '<div><span>Title: {{issue.title}}</span>' +
            '        <button class="btn btn-xs btn-default" ng-show="isHidden" data-ng-click="openClose()"><span class="glyphicon glyphicon-collapse-down"></span></button>' +
            '        <button class="btn btn-xs btn-default" ng-show="!isHidden" data-ng-click="openClose()"><span class="glyphicon glyphicon-collapse-up"></span></button>' +
            '    </div>' +
            '    <div class="issueDetails" ng-hide="isHidden">' +
            '        <div>Description</div> <div>{{issue.description}}</div>' +
            '        <div>Completion</div> <div>{{issue.completionDate | date:"fullDate"}}</div>' +
            '    </div>' +
            '    <div ng-transclude></div>'
    }
});

services.service("issueService", ["$http", "$q", "issuesResource", function ($http, $q, issuesResource) {

    this.getIssues = function () {
        return $http.get('/api/issues').then(function (response) {
            return response.data;
        });
    };

    this.getIssue = function (id) {
        return issuesResource.get({id:id});
    }

}]);

app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    $httpProvider.defaults.headers.common['X-Requested-With'] = 'Angular';

    $locationProvider
        .html5Mode(true)
        .hashPrefix('!');

    $routeProvider
        .when("/", {
            templateUrl: '/app/issues/issues.html',
            controller: 'issuesController',
            controllerAs: 'vm'
        }).when("/issues", {
            templateUrl: '/app/issues/issues.html',
            controller: 'issuesController',
            controllerAs: 'vm'
        }).when("/issues/new", {
            templateUrl: '/app/issues/new.html',
            controller: 'issueController',
            controllerAs: 'vm'
        }).when("/issue/:id", {
            templateUrl: '/app/issues/show.html',
            controller: 'issueController',
            controllerAs: 'vm'
        }).when("/issue/edit/:id", {
            templateUrl: '/app/issues/edit.html',
            controller: 'issueController',
            controllerAs: 'vm'
        }).otherwise({redirectTo: "/"})
});

app.factory("issuesResource", function ($resource) {
    return $resource('/api/issues/:id', {
        id: "@id"
    }, {
        update: {
            method: 'PUT'
        }
    });
});

// purely for test
app.factory("yetAnotherIssuesResource", function ($resource) {
    return $resource('/api/issues/:id', {

    }, {
        update: {
            method: 'PUT'
        }
    });
});
