var wasCalled = false;
function Logger(){
    this.log = function(){
        wasCalled = true;
    }
}

module('Calculator addition',{
    setup: function(){
        calc = new Calculator();
    }
});

test('Given a calculator when I add 1 and 2 then the result should be 3', function(){
    var result = calc.add(1,2);
    ok(wasCalled);
    equal(result, 3);
})

test('test add2', function(){
    var result = calc.add(11,22);
    equal(result, 33);
})

module('Calculator subtraction');

test('Can subtract two numbers', function(){
    var calc = new Calculator();
    var result = calc.subtract(11,22);
    equal(result, -11);
})
