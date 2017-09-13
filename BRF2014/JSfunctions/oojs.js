function Book(title, author) {
    this.title = title;
    this.author = author;

    var foo = "bar";

    //this.show = function () {
    //    console.log(this.title);
    //}
}

function Person(){

}

Book.prototype.show = function(){
    console.log(this.title);
};

var catch22 = new Book("Catch-22", "Heller");
var birdsong = new Book("Birdsong", "Some author");

//catch22.show();
//birdsong.show();
//
//catch22.toString();
//birdsong.toString();