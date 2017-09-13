describe('calc', function () {
    describe('add', function () {
        var calc;

        beforeEach(function () {
            calc = new Calculator();
        })

        it('should add two single digit numbers', function () {
            var result = calc.add(2, 3);
            expect(result).toBe(5);
        })

        it('should add two double digit numbers', function () {
            var result = calc.add(20, 30);
            expect(result).toBe(50);
        })

        it('should run asynchronously', function (done) {
            setTimeout(function () {
                expect(1).toBeTruthy();
                done();
            }, 500)
        });

        it('should also run asynchronously', function (done) {
            var deferred = Q.defer();

            setTimeout(function () {
                deferred.resolve();
            }, 500)

            deferred.promise
                .then(function () {
                    expect(1).toBeFalsy();
                }).fin(function(){
                    done();
                })
        });
    });
});