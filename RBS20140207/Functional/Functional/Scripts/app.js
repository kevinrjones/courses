
//function firstFunc() {
//    var i = 1;
//    j = 2;

//    console.log(i, j);
//}

//var fn = firstFunc;

//var fn = function () {
//    console.log("Hello World");
//}

//fn();

//function mintMe(a, b) {
//    if (!b) { console.log("b is false"); }
//    console.log(a, b);
//}

//mintMe(2);

//function caller(fn) {
//    fn();
//}

//function callback() {
//    console.log("was called");
//}

//caller(callback);

//caller(function () {
//    console.log("anon function called");
//});

//(function () {
//    console.log("IIFE");
//})();

function each(list, callback) {
    for (var i = 0; i < list.length; i++) {
        callback(list[i]);
    }
}

function log(item) {
    console.log(item.toString());
}

each(["kevin", "terry", "harry"], log);

var ws = function () { console.log("Web Sockets"); };
var sse = function () { console.log("Server Sent Events"); };

var callbacks = {
    WebSockets: ws,
    SSE: sse
}

function chooseProtocol(protocol) {
    return callbacks[protocol];
}

var serverCall = chooseProtocol("SSE");
serverCall();
