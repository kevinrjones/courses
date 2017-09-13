var a = 1;
var result = 3;

function adder(a, b, log) {
    var result;
    result = a + b;
    log(result);
    return result;
}

// adder(2,3, logger);

function logger(msg) {
    console.log("logger: " + msg);
}

var calc = function (a, b) {

    var res = a * b;
    logresult(res);
    return res;

    function logresult(res) {
        console.log("logresult", res);
    }
};

function adder2(a, b, log) {
    var result;
    result = a + b;
    logger(result);
    return result;
}

var names = ["Kevin", "Teresa", "Harry", "Sam", "Alex"];

function alerter(item, ndx) {
    console.log(this.toString());
}

function iterate(items, callback) {
    for (var i = 0; i < items.length; i++) {
        callback.call(items[i], items[i], i);
    }
}

//iterate(names, alert);

adder(23, 32,
    function (msg) {
        console.log("anon: " + msg)
    });


function curry(fn) {

    var args = Array.prototype.slice.call(arguments, 1);

    return function () {
        fn.apply(null, args);
    };

}

var res = curry(calc, 23, 32);

//res();

names.forEach(function(item, ndx, collection){
    console.log(item);
});


function Person(){
    var self = this;
    self.name = "Kevin";

    self.showName = function(){
        console.log(self.name);
    }
}

var kevin = new Person();

$('#clickMe').click(kevin.showName.bind(kevin));
















