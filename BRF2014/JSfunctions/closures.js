function Person(n, a) {

    var name = n;
    var age = a;
    var hitMe = true;

    this.show = function () {
        console.log(name + " is " + age + " years old");
    };

    this.update = function () {
        name = "Fred";
    };
}


var kevin = new Person("Kevin", 52);
var alice = new Person("Alice", 21);
kevin.update();

(function(){
    var k = kevin;
    var a = alice;

    setTimeout(function () {
        k.show();
        a.show();
    }, 1000);
})();



