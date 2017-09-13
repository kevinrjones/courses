describe("IssuesResource", function () {

    var httpBackend, issues;

    beforeEach(function () {
        module("app");
    });

    beforeEach(inject(function (_$httpBackend_, issueService) {
        httpBackend = _$httpBackend_;
        issues = issueService;
    }));

    it("should be defined", inject(function (issuesResource) {
        expect(issuesResource).toBeDefined();
    }));

    it("should return an array when queried", inject(function (issuesResource) {
        httpBackend.expectGET("/api/issues").respond(200, [{},{}]);
        var issues = issuesResource.query();
        httpBackend.flush();
        expect(issues.length).toBe(2);
    }));

    it("should return an object when get is called", inject(function (yetAnotherIssuesResource) {
        httpBackend.expectGET("/api/issues/1").respond(200, {id: 1});
        var issues = yetAnotherIssuesResource.get({id: 1});
        httpBackend.flush();
        expect(issues.id).toBe(1);
    }));

//    it("should return use the id passed in the object when posting", inject(function (yetAnotherIssuesResource) {
//        httpBackend.expectPOST("/api/issues/1").respond(200, {id: 1});
//        var issues = yetAnotherIssuesResource.save({id: 1});
//        httpBackend.flush();
//        expect(issues.id).toBe(1);
//    }));

    it("should return an object when get is called", inject(function (issuesResource) {
        httpBackend.expectGET("/api/issues/1").respond(200, {id: 1});
        var issues = issuesResource.get({id: 1});
        httpBackend.flush();
        expect(issues.id).toBe(1);
    }));

it("should use the id passed in the object when posting", inject(function (issuesResource) {
    httpBackend.expectPOST("/api/issues/1").respond(200, {id: 1});
    var issues = issuesResource.save({id: 1});
    httpBackend.flush();
    expect(issues.id).toBe(1);
}));

});
