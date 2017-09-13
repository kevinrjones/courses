$.validator.addMethod("inTheMysteryGang", function(val, element) {
    if (this.optional(element)) {
        return true;
    }
    return (val == "Fred" || val == "Zelma" || val == "Daphne" || val == "Shaggy" || val == "Scooby");
}, "I would have got away with it if it wasn't for those pesky, meddling kids")

