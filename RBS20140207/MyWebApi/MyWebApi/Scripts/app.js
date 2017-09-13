function Child(value) {
    this.name = ko.observable(value);
}

function User() {
    var self = this;
    this.firstName = ko.observable("Kevin");
    this.surname = ko.observable("Jones");
    this.fullname = ko.computed(function() {
        return self.firstName() + " " + self.surname();
    });
    this.onclick = function () { self.children.push(new Child("Alice")); };

    this.children = ko.observableArray([new Child("Harry"), new Child("Sam"), new Child("Alex")]);
}

$(function () {
    var kevin = new User();

    ko.applyBindings(kevin);    
});