function Calculator(logger) {
    var self = this;
    this.outcome = false;

    this.add = function (a, b) {
        logger.log("add was called");
        return a + b;
    };

    this.save = function (result) {
        $.ajax({
            url: '/save',
            success: function (result) {
                self.outcome = result.outcome;
            }});
    }
}