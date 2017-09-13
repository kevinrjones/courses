var express = require('express');
var routes = require('./routes');
var http = require('http');
var path = require('path');

var app = express();

app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');
app.use(express.favicon());
app.use(express.logger('dev'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(express.bodyParser());
app.use(app.router);
app.use(express.static(path.join(__dirname, 'public')));

// development only
if ('development' == app.get('env')) {
    app.use(express.errorHandler());
}

var clients = [];

// this is the code (in /events/index.js) that calls back on the event source when requested
var clientEvents = require('./events')(clients);
require("./routes/evtServer")(app, clientEvents);
app.get('/', routes.index);

// the event source setup - client calls this to establish as SSE connection
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

