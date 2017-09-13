$(function () {
    var url = 'http://localhost:3001/pet';
    //var url = '/pet';
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
            if (e.lengthComputable) {
                var percentComplete = e.loaded / e.total * 100;
                $('#progress').val(percentComplete);
            }
        }

        xhr.upload.addEventListener('progress', onProgressHandler, false);

        // create FormData
        var formData = new FormData($('#petowner')[0]);


        // send
        xhr.send(formData);

        return false;
    });
});
