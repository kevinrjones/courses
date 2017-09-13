var express = require('express');
var routes = require('./routes');
var user = require('./routes/user');
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
// var engineio = require('engine.io');
// all environments
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

var clientEvents = require('./events')(clients);
require("./routes/PetServer")(app);
require("./routes/evtServer")(app, clientEvents);
app.get('/', routes.index);
app.get('/ws', ws.index);
app.get('/users', user.list);
app.get('/update-stream', function (req, res) {
    // let request last as long as possible
    req.socket.setTimeout(Infinity);


    clients.push({req: req, res: res});

    //send headers for event-stream connection
    res.writeHead(200, {
        'Content-Type': 'text/event-stream',
        'Cache-Control': 'no-cache',
        'Connection': 'keep-alive'
    });
    res.write('\n');

});

var server = http.createServer(app).listen(app.get('port'), function () {
    console.log('Express server listening on port ' + app.get('port'));
});


var io = socketio.listen(server, {
    'destroy upgrade': false,
    'log level': 3
});
io.sockets.on('connection', function (socket) {
    console.log("connected");
    socket.emit('news', { hello: 'world' });
    socket.on('my other event', function (data) {
        console.log(data);
    });
});

//var io = engineio.attach(server, {'destroyUpgrade': false});
//io.on('connection', function(){
//   console.log('connected');
//});