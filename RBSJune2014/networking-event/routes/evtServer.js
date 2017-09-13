var evtServer = function (app, clients) {

    // Client posts to this url ('/evt') when they do call all the clients registered with the event source
    app.post('/evt', function (req, res) {
        clients.callClients();
        res.json("done");
    });

};

module.exports = evtServer;
