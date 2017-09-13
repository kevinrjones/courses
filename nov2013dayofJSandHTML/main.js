function onstart() {
    console.log("started");
    console.log(typeof doSomething);
    console.log("name is " + doSomething.name);
}

// anonymous function
var doSomething = function () {

}

function outer() {
    console.log("inner is " + typeof inner);

    function inner() {
        console.log("inner called")
    }
    function foo(){
        inner();
    }


    foo();

}

outer();
console.log("inner is " + typeof inner);

window.onload = onstart;

