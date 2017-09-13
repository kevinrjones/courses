var calc;
var logger = {
    log: function(){

    }
}

module("calculator", {
    setup: function(){
        calc = new Calculator(logger);
    },
    teardown: function(){

    }
});

test("should exist", function(){
    ok(calc, "should have created the calc");
});

test("should add two numbers", function(){
    var result = calc.add(2, 15);
    equal(result, 17);
});

module('logger', {
    setup: function(){

    },
    teardown: function(){

    }
});

test("should be called when numbers are added", function(){
    var logger = {};
    logger.log = sinon.spy();
    var calc = new Calculator(logger);

    calc.add(23, 32);

    ok(logger.log.called);
});


test("should set the outcome when data is saved", function(){
   var calc = new Calculator();

    sinon.stub(jQuery, "ajax").yieldsTo('success', {outcome: true});
    calc.save(23);


    ok(calc.outcome);
});