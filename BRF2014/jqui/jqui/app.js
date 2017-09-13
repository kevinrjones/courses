﻿//$('#teams').hide('bounce', function(){
//    $('#teams').show('blind', function(){
//
//    });
//});

//$(function(){
//    $('#response').animate({backgroundColor:'#888888', height: '200px'}, 'slow');
//});

$('#draggable > div')
    .draggable({
        handle: ".header",
        containment: "parent",
        revert: "invalid"
    });

$('#draggable > div').draggable('option', 'stack', '.ui-draggable');


$("#droppable")
    .droppable({
        accept: ".dropme",
        activeClass: 'opaque',
        drop: function(e, ui) {
            ui.draggable.fadeOut(function() {
                ui.draggable.remove();
            });
        }
    }
);

$('#sortable').sortable({ axis: "y" });


$('#accordian').accordion();






















//$('#teams').hide("blind",
//    function () {
//        $('#teams').show("bounce", function () {
//            $('#teams').animate({ backgroundColor: 'yellow' }, 'slow');
//        });
//
//    });
//
























//$('#draggable > div')
//    .draggable({
//        handle: ".header",
//        containment: "parent",
//        revert: "invalid"
//    });
//
//$('#draggable > div').draggable('option', 'stack', '.ui-draggable');
//
//$("#droppable")
//    .droppable({
//        accept: ".dropme",
//        activeClass: 'opaque',
//        drop: function(e, ui) {
//            ui.draggable.fadeOut(function() {
//                ui.draggable.remove();
//            });
//        }
//    }
//);
//
//
//$('#sortable').sortable({ axis: "y" });
//
//
//$('#accordian').accordion();































