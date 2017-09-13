$(function () {
//    var url = 'http://localhost:3001/pet';
    var url = '/pet';
    $('#submit').click(function () {
        var xhr = new XMLHttpRequest();
        var request = xhr.open('POST', url, true);



        var data = new FormData();

        data.append("name", $('#name').val());

        xhr.send(data);
    })
});

