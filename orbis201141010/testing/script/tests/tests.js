var calc;
var wasCalled;

module("add tests", {
    setup: function(){
        wasCalled = false;
        calc = new Calculator({log: function(){
            wasCalled = true;
        }});
    }
});

test("should add two numbers", function () {
    var result = calc.add(10, 11);

    equal(result, 21);

});

test("should add two other numbers", function () {
    var result = calc.add(22, 20);

    equal(result, 42);

});

test("should call the log method", function(){
    calc.add(1,2);
    ok(wasCalled);
})
