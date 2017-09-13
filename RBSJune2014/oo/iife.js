// Immediately Invokable Function Expression - IIFE

var person = (function (firstName, lastName) {
    var name = firstName + " " + lastName;

    function getName() {
        return name;
    }

    function getAge() {
        return 32;
    }

    return {
        getName: getName,
        age: getAge
    }
})();

// node
// requirejs

