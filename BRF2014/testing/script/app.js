function Calculator(logger){
    this.add = function(num1, num2){
        var result = num1 + num2;
        logger.log(result);
        return result;
    };

    this.subtract = function(num1, num2){
        var result = num1 - num2;
        logger.log(result);
        return result;
    }
}


