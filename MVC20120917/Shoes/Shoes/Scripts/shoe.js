$(function () {
    $("form[id='create']").submit(function () {

        $.ajax({
            url: shoeCreateUrl,
            type: this.method,
            data: $(this).serialize(),
            success: function (data) {
                $('#isDone').html(data);
            }
        });


        return false;
    });

    $('#getShoes').click(function () {
        $.get('/shoe', {}, function (data) {
            $(data).each(function () {
                $('#shoes').append($('<li>').text(this.Colour));
            });
        });
    });
    
    
});