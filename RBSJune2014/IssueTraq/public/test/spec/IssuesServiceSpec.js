describe("Issues Service", function(){
   var service;

    beforeEach(function () {
        module("app");
    });


    beforeEach(inject(function(issueService){
        service = issueService;
    }));

    it("should exist", function(){
        expect(service).toBeDefined();
    });

});
