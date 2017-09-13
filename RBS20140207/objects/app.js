////var user = {
////    name: "Kevin",
////    spouse: {
////        name: "Teresa"
////    }
////};
////
////console.log(user.spouse.name);
//
//function User(params) {
//
//    var self = this;
//
//    self.name = params.name;
//
////    self.getName = function(){
////        return "getname";
////    }
//}
//
//
//var user = new User({name: "Kevin", surname: "Jones", age: 52});
//var user1 = new User({name: "Teresa"});
//
//
//User.prototype.getName = function(){
//    return this.name;
//}
//console.log(user1.getName());
//console.log(user.getName());

function Animal(type){
    this.type= type;
}

Animal.prototype.sleep = function(){
    console.log(this.name + ". Snore! Shuffle Snore!");
};

function Dog(name) {
    var self = this;
    self.name = name;
    Animal.call(this, "dog");
    self.speak = function(){
        console.log(self.type + " Ouf");
    };
}

Dog.prototype = new Animal();

var bernie = new Dog("bernie");
console.log(bernie.constructor);
bernie.speak();
bernie.sleep();

function Cat(){

}

for(var p in bernie){
    console.log(p);
}

var elem = document.getElementById("clickme")

elem.addEventListener("click", bernie.sleep.bind(bernie));


















