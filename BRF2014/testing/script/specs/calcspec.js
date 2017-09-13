var logger = {
    log: function(){}
};

describe("Calculator", function(){
    var calc;
    beforeEach(function () {
        spy = spyOn(logger, "log");
        calc = new Calculator(logger);
    });

    it("should add two numbers", function(){
        var result = calc.add(20, 22);
        expect(result).toBe(42);
    });

    it("should subtract two numbers", function(){
        var result = calc.subtract(20, 22);
        expect(result).toBe(-2);
    });

    describe("logger", function(){
        it("should log the result to add", function(){
            calc.add(1,2);
            expect(spy).toHaveBeenCalledWith(3);
        });

        it("should log the result to subtract", function(){
            calc.subtract(1,2);
            expect(spy).toHaveBeenCalledWith(-1);
        });

    })
});
































//describe("calculator", function () {
//
//    describe("add", function () {
//
//        var calc;
//        var spy;
//
//        beforeEach(function(){
//            //spy = spyOn(logger, "log");
//        });
//
//        //it("should log", function(){
//        //    calc.add(2,3);
//        //    expect(spy).toHaveBeenCalled();
//        //})
//    });
//});
