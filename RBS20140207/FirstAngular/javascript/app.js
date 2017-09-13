var app = angular.module("app", ["myservices", "ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'people.html',
        controller: "dmPeopleController"
    }).when('/person/:id', {
            templateUrl: 'person.html',
            controller: "dmPersonController"
     }).otherwise({redirectTo: '/people'});
});

app.controller("dmPeopleController", ["$scope", "personService", function ($scope, personService) {
//    personService.getPerson().success(function(data){
//        $scope.person = data.name;
//    });

    $scope.people = [
        {id: 1, name: "Kevin", sex: "male"},
        {id: 2, name: 'Teresa', sex: "female"},
        {id: 3, name: 'Harry', sex: "male"}
    ]

    $scope.person = {id: 1, name: "Kevin", sex: "male"};
    console.log($scope.$id);

    $scope.clickMe = function (person) {
        console.log(person.name);
    }

    setTimeout(function () {
        $scope.$apply(function () {
            //    $scope.person.firstname = "Fred";
        })
        console.log("updated");
    }, 2000);
}]);

app.controller("dmPersonController", function ($scope, $rootScope, $routeParams, personService) {

    people = {};

    people["1"] = {id: 1, name: "Kevin", sex: "male"};
    people["2"] = {id: 2, name: "Teresa", sex: "female"};
    people["3"] = {id: 3, name: "Harry", sex: "male"};

    var _user;
    $scope.person = personService.getPerson();

    $scope.save = function(){
        $scope.person.$update();
    }

    $rootScope.title = $scope.person.name;
})

app.directive("dmSimple", function(){

    return {
        restrict: 'A',
        scope: {},
        replace: true,
        link: function(scope, element, attrs, controller) {
            console.log(scope.$id);
            scope.person = {};
            scope.person.name = attrs.dmSimple;
        },
        template: "<input type='text' ng-model='person.name'/>"
    }
});


app.directive("dmOther", function(){
    return{
        restrict: 'E',
        scope: {
            person: '@'
        },
        transclude: true,
        template: '<div><input type="text" ng-model="person"/><div ng-transclude></div></div>'
    }
});

app.directive("dmZippy", function(){
   return {
       restrict: 'E',
       transclude: true,
       scope: {'header':'@'},
       link: function(scope){
           scope.isContentVisible = false;
           scope.toggle = function(){
               scope.isContentVisible = !scope.isContentVisible;
           }
       },
       template: '<div><header ng-click="toggle()">{{header}}</header>' +
           '<div ng-show="isContentVisible" ng-transclude></div></div>'
   }
});



function Controller1($scope){
    $scope.data= {};
}

function Controller2($scope){

}












