function Calculator(logger) {
    this.add = function(x, y) {
        var result = x + y;
        logger.log(result);
        return result;
    }    

    this.subtract = function (x, y) {
        return x - y;
    }
}



