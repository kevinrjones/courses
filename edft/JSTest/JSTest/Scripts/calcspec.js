/// <reference path="app.js"/>

describe("Calculator", function () {

    var logger = {
        log: function() {}
    };
    var calc;
    var spy;

    beforeEach(function () {
        spy = spyOn(logger,"log");
        calc = new Calculator(logger);
    });

    it("is defined", function () {        
        expect(Calculator).toBeDefined();
    });

    it("should add two numbers", function () {
        var result = calc.add(3, 4);
        expect(result).toBe(7);
        expect(spy).toHaveBeenCalled();
    });
});