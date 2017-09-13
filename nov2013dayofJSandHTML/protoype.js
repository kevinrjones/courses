function User(name){
    this.name = name;
    this.job = "cubicle droid";
    this.showJob = function(){
        console.log("these are not the droids you are looking for");
    }
}

User.prototype.count = 0;

User.prototype.showJob = function(){
    console.log(this.job);
}

User.prototype.showName = function(){
    console.log(this.name);
    this.showJob();
}

var alice = new User("alice");
var bob = new User("bob");

alice.showName();
bob.showName();


//function Person(name) {
//    this.name = name;
//    this.showMe = function(){
//        console.log(this.name);
//    }
//}
//
//
//var alice = new Person("alice");
//console.log(alice.name);
//
//function User(name, jobTitle) {
//    Person.call(this, name);
//    this.title = jobTitle;
//}
//
//var bob = new User("bob", "drone");
//
//console.log("Name: " + bob.name + " Job: " + bob.title);
//
//bob.showMe();























