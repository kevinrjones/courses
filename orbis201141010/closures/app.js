
var people = [{
    name: "Sam",
    age: 22
},{
    name: "Alex",
    age: 22
},{
    name: "Harry",
    age: 24
}];



function increment(inc, person){
    person.age += inc;
    return person;
}

var incPersonAge = partial(increment, 2);


var updated = $.map(people, incPersonAge);

$.each(updated, function(){
   console.log(this.age);
});

function partial(fn) {
    // turn arguments into an array
    var args = Array.prototype.slice.call(arguments, 1);

    return function() {
        return fn.apply(this, args.concat(
            Array.prototype.slice.call(arguments)));
    };
}



// IIFE

//(function ($) {
//    var dataDiv = $('#data');
//
//    $(function () {
//
//        var p = $.ajax({
//            url: 'data.json',
//            accept: 'text/json'
//        });
//
//        p.done(function (data) {
//            dataDiv.text(data[0].name)
//        });
//    })
//})(jQuery);
//
//var facade = (function serverFacade($) {
//
//
//    function helper(){
//
//    }
//
//    function updateUserData() {
//        var dataDiv = $('#data');
//
//        var p = $.ajax({
//            url: 'data.json',
//            accept: 'text/json'
//        });
//
//        p.done(function (data) {
//            dataDiv.text(data[0].name)
//        });
//    }
//
//    function updateAccountData() {
//        var dataDiv = $('#data');
//
//        var p = $.ajax({
//            url: 'data.json',
//            accept: 'text/json'
//        });
//
//        p.done(function (data) {
//            dataDiv.text(data[0].name)
//        });
//    }
//
//    return {
//        updateUser: updateUserData(),
//        updateAccount: updateAccountData(),
//        obj: $('#test')
//    }
//
//})();
//
//
//facade.updateAccount();
//facade.updateUser();

//function Person(name){
//    var self = this;
//
//    this.name = name;
//    this.show = function(){
//        console.log(this.name);
//    }
//}
//
//$(function(){
//
//    var dataDiv = $('#data');
//
//    var p = $.ajax({
//        url: 'data.json',
//        accept: 'text/json'
//    });
//
//    p.done(function(data){
//        dataDiv.text(data[0].name)
//    });
//
//    var fred = new Person("Fred");
//    fred.show();
//
//    var cb = fred.show.bind(fred);
//
//
//    $('#btn').click(cb);
//
//});


//function partial(fn) {
//    // turn arguments into an array
//    var args = Array.prototype.slice.call(arguments, 1);
//
//    return function() {
//        return fn.apply(this, args.concat(
//            Array.prototype.slice.call(arguments)));
//    };
//}
//
//String.prototype.csv =
//    partial(String.prototype.split, ",");
//
//var results = ("Harry, Sam, Alex").csv();
//
//console.log(results);

//function Person(name){
//
//    var age = 23;
//
//    this.show = function(){
//        console.log(name, age)
//    }
//}
//
//var kevin = new Person("Kevin");
//
//kevin.show();
//
//var pouya = new Person("Pouya");
//
//kevin.show();


//$(function() {
//
//    var dataDiv = $('#data');
//
//    $.ajax({
//        url: 'data.json',
//        accepts: 'text/JSON'
//    }).done(function(data){
//        dataDiv.text(data[0].name);
//    });
//
//
//});


