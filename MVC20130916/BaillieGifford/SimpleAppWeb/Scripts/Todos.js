$.validator.addMethod("isInScoobysGang", function (value, element) {
    if (this.optional(element)) {
        return true;
    }
    return value == "Fred" || value == "Velma" || value == "Daphne" || value == "Shaggy";
}, "This person is not in the gang!");


$.validator.unobtrusive.adapters.addBool("gangmember", "isInScoobysGang");
