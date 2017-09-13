describe("IssuesController", function () {
    var app, issues, controller;

    beforeEach(function () {
        module("app");
    });

    beforeEach(inject(function ($controller, $rootScope, $location, $q, issueService) {
        var deferred = $q.defer();
        spyOn(issueService, "getIssues").and.returnValue(deferred.promise);
        deferred.resolve({issues:[1,2]});
        controller = $controller('issuesController', {$location: $location, issueService: issueService});
    }));

    it("should exist", function () {
        expect(controller).toBeDefined();
    });

    it("should set the typeFilterValue when type filter is called", function () {
        controller.typeFilter = 2;
        controller.filter();
        expect(controller.typeFilterValue).toBe(2);
    });

    it("should call issuesService to get current issues", inject(function($rootScope){
        $rootScope.$apply();
        expect(controller.issues.length).toBe(2);
    }));
});
