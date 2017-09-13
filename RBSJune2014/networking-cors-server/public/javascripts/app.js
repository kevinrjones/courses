$(function () {
    var url = '/pet';
    $('#submit').click(function () {
        var xhr = new XMLHttpRequest();
        xhr.open('POST', url, true);

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                var result = JSON.parse(xhr.responseText);
                if (result.done) {
                    $('#done').show(function () {
                        $('#done').hide('slow');
                    })
                }
            }
        };

        function onProgressHandler(e) {
            if (event.lengthComputable) {
                var howmuch = (event.loaded / event.total) * 100;
                console.log(howmuch);
                $('#progress').val(Math.ceil(howmuch));
            }
        }

        xhr.upload.addEventListener('progress', onProgressHandler, false);

        var formData = new FormData($('#petowner')[0]);
        xhr.send(formData);
        return false;
    });
});
