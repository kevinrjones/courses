

var age = 21;
var people = [];

function showPerson(p) {
    var msg;
    msg = p.name + " is " + p.age + " years old";
    console.log(msg);

    function foo() {
        for (var i = 0; i < people.length; i++) {
        }
        console.log(msg);
        throw "This is an exception";
    }

    return foo;
}

var person = {
    age: 52,
    married: true,
    show: showPerson
}

person.name = "Kevin";


var p = showPerson(person);
try {
    p();
} catch (e) {
    console.log(e);
}


