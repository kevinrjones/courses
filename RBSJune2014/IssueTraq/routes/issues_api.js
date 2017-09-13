var data = {
    "issues": [
        {
            "id": 1,
            "type": 0,
            "title": "Lorem ipsum",
            "description": "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            "completionDate": new Date(2017, 0, 12)
        },
        {
            "id": 2,
            "type": 0,
            "title": "Sed egestas",
            "description": "Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida id, est. Sed lectus.",
            "completionDate": new Date(2017, 0, 12)
        },
        {
            "id": 3,
            "type": 1,
            "title": "Sed egestas",
            "description": "Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida id, est. Sed lectus.",
            "completionDate": new Date(2017, 0, 12)
        }
    ]
};

var IssueServer = function (app) {

    var server = {};

    app.get('/api/issues', function (req, res) {
        var issues = [];
        data.issues.forEach(function (issue, i) {
            issues.push(issue);
        });
        res.json({
            issues: issues
        });
    });

    app.get('/api/issues/:id', function (req, res) {
        var id = req.params.id;
        if (id >= 0 && id < data.issues.length) {
            res.json(
                data.issues[id]
            );
        } else {
            res.json(false);
        }
    });

    app.post('/api/issues', function (req, res) {
        data.issues.push(req.body);
        res.json(req.body);
    });

    app.put('/api/issues/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.issues.length) {
            data.issues[id] = req.body;
            res.json(true);
        } else {
            res.json(false);
        }
    });

    app.delete('/api/issues/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.issues.length) {
            data.issues.splice(id, 1);
            res.json(true);
        } else {
            res.json(false);
        }
    });

    server.app = app;
    return server;
};


module.exports = IssueServer;