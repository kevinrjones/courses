//    $('#main').css('background-color', 'yellow')
//        .animate({backgroundColor: 'white'}, 2000, function(){
//            $('#main').animate();
//        });


$(function () {

    $('#sortable').sortable({
        axis: "y",
        stop: function (e, ui) {
            console.log('stopped');
        }
    });

    $('#draggable').children().draggable({
            containment: "parent",
            revert: true,
            handle: '.header',
            helper: 'clone'
        }
    );

    $('#draggable').children().draggable('option', 'stack', '.ui-draggable');

    $('#droppable').droppable({
        activeClass: 'opaque',
        drop: function(e, ui){
            console.log('drop');
            ui.draggable.fadeOut('slow');
        },
        accept: '#d1, #d3'

    });

    $('#accordian').accordion();
});