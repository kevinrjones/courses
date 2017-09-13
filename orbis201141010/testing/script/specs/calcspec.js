var logger = {
    log: function(){}
}

describe("calculator", function () {

    describe("add", function () {

        var calc;
        var spy;

        beforeEach(function(){
            spy = spyOn(logger, "log");
            calc = new Calculator(logger);
        });

        it("should add two numbers", function () {

            var result = calc.add(2, 3);

            expect(result).toBe(5);
        });

        it("should add two other numbers", function () {
            var result = calc.add(3, 3);

            expect(result).toBe(6);
        });

        it("should log", function(){
            calc.add(2,3);
            expect(spy).toHaveBeenCalled();
        })
    });
});
