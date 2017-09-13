function Child(name) {
    this.name = name;
}

function Person(firstName, lastName, age) {
    var self = this;

    this.children = ko.observableArray();

    $.getJSON("/api/child")
        .then(function(data) {
            $.each(data, function(ndx, child) {
                self.children.push(new Child(child.Name));
            });

    });

    this.firstName = ko.observable(firstName);
    this.lastName = ko.observable(lastName);

    this.pets = ["Bernie", "Jasper"];

    this.fullName = ko.computed(function () {
        return self.firstName() + " " + self.lastName();
    });

    this.age = ko.observable(age);

    this.childName = ko.observable();
    this.addChild = function() {
        self.children.push(new Child(self.childName()));
    }

    this.leave = function(child) {
        self.children.remove(child);
    }

    this.married = ko.observable(true);

}

$(function () {

    var kevin = new Person("Kevin", "Jones", 52);

    ko.applyBindings(kevin);

});