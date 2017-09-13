$(function () {
    var WebSocket = window.WebSocket || window.MozWebSocket;

    var time = new Date().getTime();
    var ws;
    $.get("http://localhost:3000/socket.io/1/?t=" + time, function (data) {
        var key = data.split(":")[0];
        try {
            var url ='ws://localhost:3000/socket.io/1/websocket/' + key;
            ws = new WebSocket(url);
            ws.onopen = function(e){
            }
            ws.onerror = function(e){}
            ws.onmessage = function(e){
                console.log("message: " + e.data);
            }
            ws.onclose = function(e){}

        } catch (exception) {
            console.log(exception);
        }
        $('#sendsocket').click(function () {
            ws.send('5:::{"name":"my other event","args":[{"my":"data"}]}');
        });
    });


});
