describe("The calculator", function(){
    var calc;

    beforeEach(function(){
        calc = new Calculator();
    });

    it("should exist", function(){
        expect(calc).toBeDefined();
    });

    describe("should do addition", function(){
        it("should add two numbers", function(){
            var result = calc.add(23, 32);
            expect(result).toBe(55);
        });
    });

    describe("should log results", function(){
        var logger = new Logger();

        beforeEach(function(){
            calc = new Calculator(logger);
        });

        it("should call the log method", function(){
            spyOn(logger, "log");
            calc.add(1,2);
            expect(logger.log).toHaveBeenCalled();
        });
    });
});
