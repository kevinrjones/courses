var proto;

function Person(name){
    console.log("Person ctor")
}

//Person.prototype.age = 21;

function User(name){
    console.log("User ctor");
}

function Manager(name){
    console.log("Manager ctor");
    proto = this.constructor.prototype;
}

Manager.prototype.manage = function(){
};

User.prototype = new Person();
Manager.prototype = new User();

var bob = new Manager("Kevin");



function Team(name) {
    this.name = name;

    this.getName = function(){
        return this.name;
    }

    this.toString = function(){
        return "[Team]"
    }
}

Team.prototype.print = function(){
  console.log(this.name);
};
Team.prototype.toString = function(){
    return "Prototype - toString";
}

var england  = new Team("Engerland");
var spain = new Team("Spain");

//console.log(england.getName());
//console.log(spain.getName());

