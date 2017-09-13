function Calculator(logger){
    this.add = function(x, y){
        logger.log("Add was called")

        return x + y;
    }
}


