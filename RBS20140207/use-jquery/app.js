//$('ul li').each(function(){
//    $(this).addClass('highlight');
//})

$(function(){
    $('ul li').click(function(evt){
        console.log("Clicked");
        evt.preventDefault();
        return false;
    });

    $('#getData').click(function(){
        var promise = $.get('index.html');
        promise.then(function(){
            console.log("done");
        }).fail();
        console.log("After get");
    });
});

