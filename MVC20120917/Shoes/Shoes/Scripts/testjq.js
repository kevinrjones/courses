/// <reference path="../jquery-1.7.2-vsdoc.js" />

$(function () {
    $('#oddsevens').click(function() {
        $('div ul li p:odd').css('background-color', '#eeeeee');        
        $('div ul li p:even').css('background-color', '#333333');        
    });

    $('div ul li:last p').click(function() {
        alert('last');
    });
    $('#slide').click(function() {
        $('div ul li:first').slideUp(600, callback);
    });
    $('li:last').hover(function () {
        $(this).css('background-color', 'green');
    }, function() {
        $(this).css('background-color', 'white');
    });
    function callback() {
        $(this).show().effect("highlight", {}, 2500);
    }

    $('#getData').click(function () {
        $.ajax({
            'type': 'get',
            'url': itemIndexUrl
        }).done(function (results) {
            $(results).each(function() {
                $('ul').append($('<li>').text(this.Title));
            });
        });
    });
});