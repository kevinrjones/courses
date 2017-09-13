$(function () {
    console.log("starting");
    var promise = $.signalR.hub.start();
    promise.then(function () {
        $.signalR.movieHub.server
            .getMovies().then(function (data) {
                console.log(data);
            });
    });

    $('#send').click(function() {
        $.signalR.movieHub.server.sendMessage($('#message').val());
    });

    $.signalR.movieHub.client.broadcastMessage = function(message) {
        console.log(message);
    }
});