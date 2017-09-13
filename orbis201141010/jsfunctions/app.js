

var people = []

people.push({name: 'Kevin'});
people.push({name: 'Harry'});
people.push({name: 'Sam'});

//
//for(var i = 0; i < people.length; i++ ){
//    console.log(people[i].name);
//}

function each(collection, callback){
    for(var i = 0; i < collection.length; i++ ){
        callback.call(collection[i], i, collection[i]);
    }
}

each(people, function(){
   console.log(this.name);
});




//// constructor function
//function Person(_name, _age) {
//    var self = this;
//
//    this.name = _name;
//    this.age = _age;
//
//    this.showPerson = function () {
//        console.log(self.name + " is " + self.age + " years old")
//    };
//}
//
//var kevin = {
//    name: "Kevin",
//    age: 52,
//    show: function() {
//        console.log("This is " + this.name)
//    }
//};
//
//kevin.show();
//
//var alice = new Person("Alice", 22);
//var fred = new Person("Fred", 21);
//fred.showPerson();
//
//function showPerson(a, b) {
//    console.log(a, b);
//    console.log(this.name + " is " + this.age + " years old")
//};
//
//showPerson.call(fred, "foo", "bar");
//
//var teresa = {
//    show: fred.showPerson
//};
//
//teresa.show.call(fred);
//
//function callMe(name){
//    console.log(this);
//    console.log(name);
//}

//function show(name, age) {
//
//    console.log(name + " is " + age + " years old");
//    var args = Array.prototype.slice.call(arguments)
//}

//var foo = {
//    0: "Kevin",
//    1: 52,
//    length: 2
//};
//
//var args = Array.prototype.slice.call(foo)

//show("Kevin", 52);
//
//var kevin = {};
//
//kevin.show = show;
//kevin.show("kevin", 53, "what an idiot");


//function add(x, y) {
//    return x + y;
//}
//
//function returnMe() {
//    console.log("returned")
//}
//
//function showDetails() {
//    console.log("these are the details");
//    return returnMe;
//}
//
//var myfunc = showDetails;
//
//var func = myfunc();
//func();
//
//var newFunc = function () {
//    console.log("this is a function");
//};


