describe("Calculator", function(){
    it('should exist', function(){
       expect(Calculator).toBeDefined();
    });

    var calc;

    beforeEach(function(){
         calc = new Calculator();
    });

    it("should be able to add two numbers", function(){

        var spy = spyOn(calc, "add").and.callThrough();

        var result =  calc.add(23,32);

        expect(result).toBe(55);
        expect(spy).toHaveBeenCalled();
    })
});