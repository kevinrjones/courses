var express = require('express');
var routes = require('./routes');
var ws = require('./routes/ws');
var http = require('http');
var path = require('path');

var app = express();

var allowCrossDomain = function (req, res, next) {
    res.header('Access-Control-Allow-Origin', "*");
    res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
//    res.header('Access-Control-Allow-Headers', 'Content-Type');

    next();
};

var socketio = require('socket.io');
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');
app.use(express.favicon());
app.use(express.logger('dev'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(express.bodyParser());
app.use(allowCrossDomain);
app.use(app.router);
app.use(express.static(path.join(__dirname, 'public')));

// development only
if ('development' == app.get('env')) {
    app.use(express.errorHandler());
}

var clients = [];

// this is the code (in /events/index.js) that calls back on the event source when requested
app.get('/', routes.index);
app.get('/ws', ws.index);


var server = http.createServer(app).listen(app.get('port'), function () {
    console.log('Express server listening on port ' + app.get('port'));
});


var io = socketio.listen(server, {
    'destroy upgrade': false,
    'log level': 3
});

var sockets = [];
var _ = require('underscore');

io.sockets.on('connection', function (socket) {
    console.log("connected");
    sockets.push(socket);
    socket.emit('news', { hello: 'world' });
    socket.on('my other event', function (data) {
        console.log('my other event: ', data);
        _.each(sockets, function (socket) {
            socket.emit('news', { hello: new Date() });
        });
    });
});

