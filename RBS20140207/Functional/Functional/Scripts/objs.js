var i = 5;

var person = {
    name: "Kevin",
    age: 34,
    birthday: function () {
        console.log(this.age++);
    }
};