var evtServer = function (app, client) {

    app.post('/evt', function (req, res) {
        client.callClients();
        res.json("done");
    });

};

module.exports = evtServer;
