/// <reference path="jquery-1.7.2-vsdoc.js"/>


$(function () {
    $('#oddeven').click(function () {
        $('div ul li:even p').css('background-color', '#eee');
        $('div ul li:odd p').each(function () {
            $(this).css('background-color', '#333');
        });
    });

    $('div.wrapper ul li:last p').click(function () {
        alert('last');
    });

    $('li:last p').hover(function () {
        $(this).css('background-color', 'green');
    },
    function () {
        $(this).css('background-color', '#eee');
    });

    $('#slide').click(function () {
        $(this).slideUp(300, function () {
            $('#slide').show().effect("highlight", {}, 2500);
        });
    });

});


(function ($) {
    $.validator.unobtrusive.adapters.addBool(
            "namevalidation", "nameValidationMethod");
    $.validator.addMethod("nameValidationMethod",
           function (value, element) {
               return this.optional(element) || value.toLowerCase() !== value;
   });

}
(jQuery));
