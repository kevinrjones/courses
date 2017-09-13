function Person(name) {
    this.name = name;
}

$(function () {
    function Company() {
        var self = this;

        self.users = ko.observableArray([
            new Person("alice"),
            new Person("bob"),
            new Person("charlie"),
            new Person("david"),
            new Person("ethel")
        ]);
        self.name = ko.observable("Credit Suisse");
        self.userName = ko.observable();

        self.fullName = ko.computed(function(){
            return self.name() + " " + self.userName();
        });

        self.addUser = function () {
            self.users.push(new Person(self.userName()));
        }
    }

    var company = new Company();


    ko.applyBindings(company);
});





