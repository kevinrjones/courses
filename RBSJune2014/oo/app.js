var kevin = {
    firstName: "Kevin",
    lastName: "Jones"
};

var people = [];

people.push(kevin);
people.push({firstName: "Teresa"});

function log(msg) {
    console.log(this);
    console.log(msg);
}

// constructor function
function Person(params) {
    var self = this;

    this.firstName = params.firstName;
    var lastName = params.lastName;

    this.getName = function () {
        return firstName + " " + lastName;
    }
}

Person.prototype.instances = 0;


var terry = new Person({firstName: "Teresa", lastName: "Jones"});

Person.prototype.count = function () {
    Person.prototype.instances++;
};

var kevin = new Person({firstName: "Kevin", lastName: "Jones"});

kevin.count = function(){
    return "ha ha";
}

function helper(o){
    if(o instanceof Person) {
        console.log(o.firstName);
    } else {

    }

}

helper(kevin);




























