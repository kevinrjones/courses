var values = [1, 2, 3, 4];

var answer = values.reduceRight(function (previous, current, index, list) {
    console.log(previous);
    return previous + current;
});

console.log(answer);

