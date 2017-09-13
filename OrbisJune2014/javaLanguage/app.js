var ns = ns || {};

ns.a = 1;

console.log(typeof a)

ns.kevin = {
    name: 'Kevin'
};

console.log(typeof kevin)


function print() {
    'use strict';
    var instructor = "Kevin";
    throw "This is an exception"
}

try {
    print()
} catch (e) {
    console.log(e);
}
