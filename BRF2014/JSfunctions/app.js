var person = {
    name: 'Kevin'
};

function showDetails(d) {
    // arguments
    // this => call context
    console.log("These are the details " + d.name);
}

function showDetails2() {
    console.log("details 2");
}

var fn = showDetails;

var fn2 = function () {
    console.log("this is also a function");
};


person.show = showDetails2;


//person.show();








