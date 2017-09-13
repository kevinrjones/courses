var data = {
    "lists": [
        {
            id: 1,
            title: "Todo",
            activities: [
                {
                    name: "Finish chapter",
                    priority: 3
                },
                {
                    name: "Do lab",
                    priority: 2
                },
                {
                    name: "Watch football",
                    priority: 5
                }
            ]
        },
        {
            id: 2,
            title: "Project X"
        }
    ]
};

// GET

var JelloServer = function (app) {

    var server = {};
    var _ = require('underscore');

    app.get('/api/list', function (req, res) {
        res.json(data.lists);
    });

    app.get('/api/list/:id', function (req, res) {
        var id = req.params.id;
        if (id >= 0 && id < data.lists.length) {
            var lists = _.map(data.lists, function (list) {
                if (list.id == id) {
                    return list
                }
            });
            if (lists.length > 0) {
                return  res.json(lists[0]);
            }
        }
        res.json(false);
    });

    app.post('/api/list', function (req, res) {
        data.lists.push(req.body);
        res.json(req.body);
    });

    app.put('/api/list/:id', function (req, res) {
        var id = req.params.id;
        console.log(id);
        res.json(true);
    });

    app.delete('/api/list/:id', function (req, res) {

        var id = req.params.id;

        if (id >= 0 && id < data.lists.length) {
            data.lists.splice(id, 1);
            res.json(true);
        } else {
            res.json(false);
        }
    });

    server.app = app;
    return server;
};

module.exports = JelloServer;