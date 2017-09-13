var PetServer = function (app) {

    var done = {msg: 'done'};

    app.post('/pet', function (req, res) {
        console.log(req.body.name);
        console.log(req.body.pet);
        res.json(done);
    });
    app.get('/pet', function (req, res) {
        console.log(req.body.name);
        console.log(req.body.pet);
        res.json(done);
    });
};

module.exports = PetServer;
