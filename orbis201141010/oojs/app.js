
var orbis = orbis || {};

orbis.owl = orbis.owl || {};


function Person(name){
    this.name = name;
}

Person.prototype.helpMe = function(){}

function User(name){

    Person.apply(this, [name]);

    this.logon = function(){

    }
}

User.prototype = new Person();

User.prototype.showName = function(){
    console.log(this.name, this._age)
};


var kevin = new User("Kevin");
var teresa = new User("Teresa");

console.log(kevin.toString());

var p = new Person("Kevin");













