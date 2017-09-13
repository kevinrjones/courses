var app = angular.module("seasonTicket");


app.service("countryService", function ($http) {
    this.getCountries = function () {

        //var promise = $http.get("/api/countries");
        //return promise;
        return [
        {
            name: "Scotland",
            id: 2,            
        }, {
            name: "Ireland",
            id: 3
        }, {
            name: "England",
            id: 4
        }
        ];
    }
});
































