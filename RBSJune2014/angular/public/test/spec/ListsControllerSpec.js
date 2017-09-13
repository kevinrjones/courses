describe("ListsController", function () {
    var app, issues, controller, scope;
    var $httpBackend;

    beforeEach(function () {
        module("app");
    });

    beforeEach(inject(function ($controller, $rootScope, $location, ListService, _$httpBackend_) {
        scope = $rootScope.$new();
        $httpBackend = _$httpBackend_;
        $httpBackend.expectGET("/api/list").respond(200, [{},{}]);
        controller = $controller('ListsController', {$location: $location, ListService: ListService, $scope: scope});
    }));

    it("should exist", function () {
        expect(controller).toBeDefined();
    });

    it("should call listService to get current list", inject(function($rootScope){
        $rootScope.$apply();
        $httpBackend.flush();
        expect(scope.lists.length).toBe(2);
    }));
});
