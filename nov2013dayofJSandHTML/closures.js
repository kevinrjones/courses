var innner;


function outerfunction() {

    var innerState = "inner state";

    function innerFunction() {
        console.log(innerState);
    }

    inner = innerFunction;
}


outerfunction();
inner();


//function Person(name, job){
function Person(params) {
    var _name = params.name;
    var _jobTitle = params.job;

    this.showDetails = function () {
        // using a closure over the parameters
//        console.log(name + " is a " + job);
        // using a closure over the vars
        console.log(_name + " is a " + _jobTitle);
    }
}


var alice = new Person({name: "alice", job:"manager"});

alice.showDetails();
console.log("Person is called " + alice._name);

function bind(context, name) {
    return function() {
        return context[name].apply(context, arguments);
    };
}


$(function(){

    function MyButton() {
        this.isClicked = false;
        this.handleClick = function() {
            this.isClicked = true;
            console.log("Click handled");
        }
        this.handleClick2 = function() {
            this.isClicked = true;
            console.log("Click handled 2");
        }
    }

    btn = new MyButton();

    var fn = bind(btn, "handleClick");

    // what's really happening
//    var fn1 = function() {
//        return btn["handleClick"].apply(btn, arguments);
//    };
//    var fn2 = function() {
//        return btn["handleClick2"].apply(btn, arguments);
//    };

    $('#mybutton').click(fn1);

    $('#anotherbutton').click(fn2);


});














