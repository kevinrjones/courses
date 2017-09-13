var app = angular.module("seasonTicket", []);


app.controller("seasonTicketCtrl", function ($scope, countryService) {
    var app = this;
    app.ticket = {
        owner: "Fred Smith",
        value: 4000
    }

    app.showMe = function() {
        alert('shown');
    }

    $scope.addCountry = function() {
        $scope.countries.push({ name: 'Greece', id: 5 });
    }

    $scope.countries = countryService.getCountries();

    $scope.message = "";

    //countryService.getCountries().then(function (response) {
    //    $scope.countries = response.data;
    //});

});

app.directive("dmUser", function() {
    return {
        restrict: "E",
        controller: function() {},
        replace: true,
        scope: {
            msg: "@",            
            show: "&"
        },
        link: function(scope, element) {
            scope.name = "Kevin";
            scope.alert = function () { alert('hello world'); }
        },
        transclude: true,
        template: "<div class={{className}}><div>Hello {{name}}</div>" +
            "<div ng-transclude></div>" +
            "<input type='text' ng-bind='msg' />" +
            "<div>{{msg}}</div>" +
            "<button ng-click='show()'>Click Me</button></div>"
    }
});

















































