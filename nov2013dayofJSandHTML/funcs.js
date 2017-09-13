//function doWork(name, jobTitle) {
//    console.log("doing work for " + name + " who is a " + jobTitle + " and this is " + this);
//}
//
//
//var worker = doWork;
//
//
//doWork("Alice", "manager", 23, 14, 97);
//worker("Bob", "coder");

var person = {
    name: 'Charlie',
    jobTitle: 'cleaner',
    doWork: function () {
        console.log("Called doWork. this is " + this);
    }
};

console.log("===========");
console.log(person.name);
person.doWork();

var worker = person.doWork;
worker();
worker.call(person);

//function Person(name, job){
//    var self = this;
//    self.name = name;
//    self.jobTitle = job;
//
//    self.showDetails = function(){
//        console.log(self.name + " is a " + self.jobTitle);
//    }
//}
//
//
//var alice = new Person("alice", "manager");
//var bob =  new Person("bob", "coder");
//
//
//alice.showDetails();
//bob.showDetails();
//
//var showDetails = bob.showDetails;
//showDetails();
//showDetails = alice.showDetails;
//showDetails();
//

function forEach(collection, fn) {
    for (var i = 0; i < collection.length; i++) {
        fn.call(collection[i], i, collection[i]);
    }
}


var names = ["Alice", "Bob", "Caharlie"];

forEach(names, function(ndx, item){
    console.log(this.toString());
});

//for(var i = 0; i < names.length; i++){
//    console.log(names[i]);
//}















