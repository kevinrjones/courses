function animal(self){
    self.sleep = function(){
        console.log("Zzzzz!");
    }
}

function Dog(){
    animal(this);

    this.speak = function(){
        console.log("Bow wow!");
    };
}

var fido = new Dog();
fido.sleep();
fido.speak();

function talk(obj){
    if(obj != undefined && obj.speak != undefined){
        obj.speak();
    } else {
        throw "Oops";
    }
}

function Parliamentarian(){
    this.speak  = function(){}
}

var a = new Parliamentarian();

talk(fido);
talk(a);
talk({speak: function(){}})