function Person(name, job) {

    var n = name;

    this.display = function () {
        console.log(n, job);
    }
}

var kevin = new Person("Kevin", "Dev");

kevin.display();

//
//function print(msg){
//    console.log(msg, this);
//}
//
//print("Hello from window");
//
//var user = {};
//user.print = print;
//
//user.print("Hello from user");

//function each(items, callback){
//    for(var ndx = 0; ndx < items.length; ndx++){
//        var item = items[ndx];
//        callback.call(item, ndx, item, items);
//    }
//}
//
//var users = [];
//
//users.push({name: "Alice"});
//users.push({name: "Bob"});
//
//each(users, function(){
//   console.log(this.name);
//});

function Person1(name){
    var self = this;
    this.name = name;

    this.print = function(){
        console.log(self.name);
    }
}

var alice = {
    name: "Alice",
    print: function(){
        console.log(this.name);
    }
};

var bob = new Person1("Bob");
$('#button').click(bob.print);

//$('#button').click(alice.print.bind(alice));

// constructor

//function Person(params) {
//
//    var name = params.name;
//
//    function doStuff() {
//    }
//
//    this.job = params.job;
//
//    this.display = function () {
//        doStuff();
//        console.log(name, this.job);
//    }
//}
//
//var kevin = new Person({name: "Kevin", job: "Developer"});

// constructor - end

// calling functions and this
//function printName(name){
//    console.log(name);
//    console.log(this.name);
//}
//
//printName("Kevin");
//
//var user = {
//    print: printName,
//    name: "Kevin"
//};
//
//var userPrint = user.print;
//
//
//var person = {};
//
//person.print = function(){
//    console.log("Person print");
//};
// calling functions and this - end

// Simple functions
//function print(msg){
//    console.log(msg);
//}
//
//var p = print;
//
//print("Hello from print");
//
//p("Hello from p");
//
//var printer = function(msg){
//  console.log(msg);
//};
//
//printer("Hello from printer");
//
//var user = function(){
//    doSomething();
//
//   function doSomething(){
//        console.log("I did something");
//    }
//
//};
//
//user();
//
//console.log("Trying to do something");
//user.doSomething();

// Simple functions - end