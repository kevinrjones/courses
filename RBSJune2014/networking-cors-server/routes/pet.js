/*
 * GET home page.
 */

var PetServer = function (app) {
    app.post('/pet', function (req, res) {
        console.log(req.body.pet);

        var fs = require('fs');
        fs.readFile(req.files.filename.path, function (err, data) {

            var newPath = __dirname + "/uploads/uploadedFileName";
            fs.writeFile(newPath, data, function (err) {
                if(err) {
                    console.log(err);
                } else {
                    res.json({done: true});
                }
            });
        });
    });

};
module.exports = PetServer;