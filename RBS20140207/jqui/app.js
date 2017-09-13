$(function(){
    var main = $('#main');
    main.hide();
    $('#animate').click(function(){
//        main.switchClass('lightblue', 'red');
        main.show(5000, 'easeOutBounce')
//        main.effect('pulsate', function(){
//            main.hide('blind', function(){
//                main.show('bounce', function(){
//                    main.animate({backgroundColor: '#ffb6c1'}, 'slow', function(){
//                        main.switchClass('lightBlue', 'red');
//                    })
//                })
//            });
//        });
    });

    $('.draggable').draggable({
        stack: '.ui-draggable',
        //containment: '#container',
        handle: 'header'
    });

    $('#dropTarget').droppable({
        activeClass: 'opaque',
        accept: '#three',
        drop: function(event, ui) {
            ui.draggable.remove();
        }
    });

    $('#sortable').sortable({
        axis: "y",
        placeholder: 'placeholder'
    });

    $('#dob').datepicker();

    $('#accordion').accordion({
        heightStyle: 'content'
    });

    $('#tabs').tabs();
});
