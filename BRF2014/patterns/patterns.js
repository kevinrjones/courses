var brf = brf || {};

brf.utilities = brf.utilities || {};

brf.utilities.showMe = function () {
};

brf.instructor = "Kevin";

// Immediately Invokable Function Expression
// IIFE
// revealing module pattern
brf.service = (function () {

    function helper() {
    }

    function getPeople() {
        helper();
    }

    return {
        getPeople: getPeople
    }
})();
service.getPeople();

// IIFE
// module pattern
// angular $window
(function ($, window){
    $('h2').click(function () {
        window.location.href = "";
    });
})(jQuery, window);




























