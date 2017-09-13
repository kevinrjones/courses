$(function () {
    $.connection.hub.start().done(function () {
        console.log("connected");
    });
    $('#getuser').click(function () {
        $.connection.userHub.server.getUser(1)
            .done(function (data) {
                console.log(data);
            });
    });

    $.connection.userHub.client.update = function(data) {
        console.log(data);
    };
});