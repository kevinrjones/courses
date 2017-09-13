var handleEvents = function (clients) {

    var _ = require('underscore');
    var messageCount = 0;
    return {
        callClients: function () {
            // for each client
            _.each(clients, function (client) {
                messageCount++; // Increment our message count
                if (client.res) {
                    var sent = client.res.write('id: ' + messageCount + '\n');
                    console.log("message");
                    if (sent) {
                        client.res.write("data: " + 'hello' + '\n\n'); // Note the extra newline
                    } else {
                        client.res = null;
                    }
                }
            });
        }
    }
};

module.exports = handleEvents;
