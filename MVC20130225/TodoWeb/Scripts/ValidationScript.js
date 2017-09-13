$.validator.unobtrusive.adapters.addSingleVal(
                       "maxdays", "howlong", "maxDaysValidator");

$.validator.addMethod("maxDaysValidator",
   function (value, element, param) {
       return this.optional(element) || parseInt(value) <= parseInt(param);
   }
);

// this adds to the unobtrusive validation
// but you also need the Html.ValidationMessage helper
$(function () {
    $('#myform input[id="other"]').rules("add", {
        required: true,
        messages: {
            required: "Required input"
        }
    });
});