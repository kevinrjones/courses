var people = [
    { name: "Alice" }, 
    { name: 'Bob' }, 
    { name: "Charlie" },
    { name: "Deepak" },
];



function log() {
    console.log(this.name);
}

function each(collection, fn) {
    for (var i = 0; i < collection.length; i++) {
        fn.call(collection[i], collection[i], i);
    }
}

function doSomething(msg) {
    return function() {
        console.log(msg);
    }
}

var fn = doSomething("Hello world");
var fn2 = doSomething("Goodbye cruel world, I'm leaving you today, goodbye, goodbye, goodbye");


function loop() {
    each(people, function() {
        console.log(this.name);
    });
}