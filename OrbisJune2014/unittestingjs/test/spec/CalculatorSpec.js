describe("The calculator", function () {
    var calc;
    var logger = {
        log: function () {
        }
    };
    beforeEach(function () {

        spyOn(logger, "log");
        calc = new Calculator(logger);
    });

    it("should exist", function () {
        expect(calc).toBeDefined();
    });

    it("should add two numbers", function () {
        var result = calc.add(23, 41);
        expect(result).toBe(64);
    });

    it("should call the log function", function () {
        calc.add(23, 32);
        expect(logger.log).toHaveBeenCalled();
    });
});
