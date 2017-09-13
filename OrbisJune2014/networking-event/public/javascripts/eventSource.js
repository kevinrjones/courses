$(function () {
    // register with an event source (see app.js)
    var es = new EventSource("/update-stream");
    es.addEventListener('message', function (e) {
        console.log(e.data);
    }, false);

    // when clicked on this url sends an post to the server that causes the server to
    // trigger SSE callbacks
    $('#sendevent').click(function () {
        $.post('evt');
    });
});
