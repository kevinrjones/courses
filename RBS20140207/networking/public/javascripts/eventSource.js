$(function(){
    var es = new EventSource('/update-stream');

    es.addEventListener('message', function(e){
        console.log(e.data);
    });

    $('#sendevent').click(function(){
        $.post('/evt');
    });
});
