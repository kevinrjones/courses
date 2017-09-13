$(function() {
    $.connection.hub.start().done(function() {
        console.log("started");
    });

    $.connection.personHub.client.person = function (data) {
        console.log(data.Name);

    }
});