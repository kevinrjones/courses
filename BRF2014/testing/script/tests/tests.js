var calc;
var wasCalled;

module("Calculator tests", {
    setup: function(){
        wasCalled = false;
        calc = new Calculator({log: function(){
            wasCalled = true;
        }});
    },
    teardown: function(){

    }
});

test("should log the result for add", function(){
    var result = calc.add(11, 23);
    ok(wasCalled);
});

test("should add two numbers", function(){
    var result = calc.add(11, 23);
    equal(result, 34);
});

test("should subtract two numbers", function(){
    var result = calc.subtract(23, 11);
    equal(result, 12);
});