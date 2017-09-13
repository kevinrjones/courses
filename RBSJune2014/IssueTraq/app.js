/**
 * Module dependencies.
 */

var express = require('express')
    , favicon = require('serve-favicon')
    , bodyParser = require('body-parser')
    , methodOverride = require('method-Override')
    , cookieParser = require('cookie-parser')
    , session = require('express-session')
    , logger = require('morgan')
    , routes = require('./routes')
    , http = require('http')
    , errorHandler  = require('errorhandler')
    , lessMiddleware = require('less-middleware')
path = require('path');

var app = express();

// all environments
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.engine('html', require('ejs').renderFile);
app.use(favicon(__dirname + '/public/favicon.ico'))
app.use(logger('dev'));
app.use(lessMiddleware(path.join(__dirname, 'public'), { src: __dirname + '/public', debug: true }));
app.use(express.static(path.join(__dirname, 'public')));

app.use(bodyParser());
app.use(methodOverride());
app.use(cookieParser());

app.use(session({ secret: 'seed seed seed seed',  cookie: { httpOnly: false } }));

// development only
if ('development' == app.get('env')) {
    app.use(errorHandler());
}

app.get('/', routes.index);
require("./routes/issues_api")(app);


app.get('/*', routes.index);
http.createServer(app).listen(app.get('port'), function () {
    console.log('Express server listening on port ' + app.get('port'));
});
