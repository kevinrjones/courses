$(function() {

    $.connection.tennisHub.client.newScore = function (player, score) {
        console.log(player, score);
    }

    $.connection.hub.start().done(function () {
        console.log("Started");
    });

});