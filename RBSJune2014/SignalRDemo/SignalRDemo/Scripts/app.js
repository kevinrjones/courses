$(function() {

    $.connection.hub
        .start()
        .done(function () {
            $.connection.personHub
                .server.getPeople().
            done(function(people) {
            $.each(people, function(ndx, item) {
                console.log(item.Name);
            });
        });
        });

    $.connection.personHub.client.update = function(person) {
        console.log(person.Name);
    }
});