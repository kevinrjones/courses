var app = angular.module("app", []);

app.controller("simpleController", function ($scope, classroomService) {
    var person = {
        name: "Kevin"
    };

    $scope.showDetails = function () {
        $scope.course.visible = !$scope.course.visible;
    };

    $scope.person = person;

    $scope.course = classroomService.getClassRoom();
});

app.service("classroomService", function ($http) {
    var getClassRoomData = function () {
        return {
            visible: false,
            instructor: {
                name: "Kevin",
                course: "Angular"
            },
            students: [
                {
                    name: 'Alice',
                    dept: 'Finance'
                },
                {
                    name: 'Bob',
                    dept: 'IT'
                }
            ]
        };
    };

    return {
        getClassRoom: getClassRoomData
    }

});


app.directive("dmSimple", function () {
    return {
        restrict: "EA",
        scope: {
            course: "="
        },
        template: "<div><span>This is a template {{name}} - {{course}}</span>" +
        "<span ng-transclude></span>" +
            "<input type=text ng-model='course'/>"+
        "</div>",
        link: function (scope, http) {
            scope.name = "Kevin"
        },
        transclude: true
    }
});




