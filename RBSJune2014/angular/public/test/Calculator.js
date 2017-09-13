function Calculator(logger) {
    this.add = function (a, b) {
        var result = a + b;
        if (logger) {
            logger.log("The result was " + result);
        }
        return result;
    }
}

function Logger() {
    this.log = function (msg) {

    }
}
