function callMe(a, b) {
    console.log(this);
    console.log(a, b);
}

console.log("with call");
callMe.apply(window, [2, 3]);

var user = {
    name: "Kevin",
    printName: function () {
        console.log(this);
        console.log(this.name);
    }
}

var other = {
    name: "Teresa"
}

user.printName();
user.printName.call(other);

//$("#btn").click(user.printName.bind(user));


user.buttonHandler = function () {
    var self = this;
    var name = "Kevin";

    $('#btn').click(function () {
        console.log(self);
    });
    console.log("Leaving function. Scope?");
}

user.buttonHandler();