$(function () {

    var people = [{
        name: "Harry",
        age: 24
    },
        {
            name: "Sam",
            age: 22
        }]

    $(people).each(function () {
        console.log(this.name + " is " + this.age + " years old");
    });

    var older = $(people).map(function (ndx, item) {
        return {
            name: item.name,
            age: item.age + 1
        };
    });

    $(older).each(function () {
        console.log(this.name + " is " + this.age + " years old");
    });


    $('h2').click(function () {
        console.log("Clicked on");
    });
});
