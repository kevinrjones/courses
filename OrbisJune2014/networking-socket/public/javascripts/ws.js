$(function () {
    var WebSocket = window.WebSocket || window.MozWebSocket;

    var time = new Date().getTime();
    $.get("http://localhost:3000/socket.io/1/?t=" + time, function (data) {
        console.log(data);
        var key = data.split(":")[0];
        try {

            var ws = new WebSocket('ws://localhost:3000/socket.io/1/websocket/' + key);

            ws.onopen = function (e) {
                console.log("open");
                //ws.send('Hi!');
            };

            ws.onerror = function (e) {
                console.log(e);
            };

            ws.onclose = function (e) {
                console.log(e);
            };

            ws.onmessage = function (e) {
                console.log('Server: ' + e.data);
            };
        } catch (exception) {
            console.log(exception);
        }
        $('#sendsocket').click(function () {
            ws.send('5:::{"name":"my other event","args":[{"my":"data"}]}');
        });
    });


});
