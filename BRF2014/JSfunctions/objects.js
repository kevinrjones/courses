//var kevin = {
//    name: "Kevin",
//    age: 52
//};
//
//var alex = {
//    name: 'alex',
//    age: 22
//};

function Person(n, a) {
    var name = n;
    var self = this;
    this.age = a;

    this.getName = function(){
        return name;
    };

    this.setAge = function(a){
        this.age = a;
    };

    this.show = function(){
        console.log(name + " is " + self.age + " years old");
    };

    this.alert = function(){
        alert(name + " is " + this.age + " years old");
    };
}

//var kevin = new Person("Kevin", 52);
//
//var fn = kevin.show;
//
//fn();

$(function(){

    var kevin = new Person("Kevin", 52);
    var alice = new Person("Alice", 21);

    $('#show').click(kevin.alert.bind(kevin));

});
