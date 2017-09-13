function helper(self) {
    self.newHelper = function() {}
}

function Person(name, age) {
    var self = this;

    helper(this);

    var fn = function () {

    }

    this.name = name;
    this.age = age;

    this.click = function() {
        console.log(self.name);
    }
}

Person.prototype.display = function () {
    console.log(this.name + " is " + this.age + " years old");
}

function Student(name, age) {
    Person.apply(this, [name, age]);
}

Student.prototype = new Person();

var kevin = new Student("Kevin", 21);
// kevin.__proto__= Person.prototype;
kevin.display = function () {
    console.log("this is Kevin");
}
var fred = new Person("fred", 52);
var teresa = new Person("Teresa", 21);
var sam = new Person("Sam", 21);
var alex = new Person("Alex", 21);



//var kevin = {
//    name: "Kevin",
//    display: function() {
//        console.log(this.name);
//    }
//}


function meeting(name) {
    function display() {
        console.log(name);
    }

    return {
        display: display
    }
}


var agm = meeting("agm");

agm.display();

var helpers = (function($) {
    
    return {
        each: $.each
    }
})(jQuery);


