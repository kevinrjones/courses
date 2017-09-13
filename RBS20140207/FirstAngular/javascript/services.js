var services = angular.module("myservices", ["ngResource"]);

app.factory("Users", function ($resource) {
    return $resource('person.json/:id', {
        id: '@id'
    }, {
        update: {
            method: 'PUT'
        }
    });
});


services.service("personService", function($http, $resource, Users){
    this.getPerson = function(){
//        return $http.get("person.json");
        return Users.get();
    }
});






























