var people = [
    {
        name: 'Sam',
        age: 22
    },
    {
        name: 'Alex',
        age: 22
    },
    {
        name: 'Harry',
        age: 24
    }
];

//function showPerson() {
//    // this == person
//    console.log(this.name + " is " + this.age + " years old.")
//}

//for (var i = 0; i < people.length; i++) {
//    showPerson(people[i]);
//}

function forEach(collection, callback) {
    for (var i = 0; i < collection.length; i++) {
        var context = collection[i];
        callback.apply(context, [i, collection[i]]);
    }
}

console.log("using forEach");

forEach(people, function () {
    console.log(this.name + " is " + this.age + " years old......");
});





















