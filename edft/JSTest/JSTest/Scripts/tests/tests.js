/// <reference path="../app.js"/>

var calc;
var logger;
var wasCalled;

module("Calculator", {
    setup: function () {
        wasCalled = false;
        logger = {log: function() {
            wasCalled = true;
        } }
        calc = new Calculator(logger);
    }
});

test("is defined", function () {
    ok(Calculator);
});

test("Should add two numbers", function() {

    var result = calc.add(2, 3);

    equal(result, 5);
});

test("Should subtract two numbers", function () {

    var result = calc.subtract(3, 2);

    equal(result, 1);
});

test("Should log the result when adding two numbers", function() {
    calc.add(2, 3);
    ok(wasCalled);
});



























