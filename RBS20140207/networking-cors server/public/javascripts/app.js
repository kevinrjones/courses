$(function () {
    var progress = $('#uploadProgress');
    progress.val(0);
    $('#submit').click(function (evt) {
        evt.preventDefault();
        progress.val(0);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'http://localhost:3001/pet', true);
        //xhr.responseType = "json";
        xhr.onreadystatechange = function (e) {
            console.log(e);
            if (xhr.readyState === 4 &&
                xhr.status === 200) {
                if (xhr.responseType == "text" || xhr.responseType == '') {
                    console.log(xhr.responseText);
                } else if (xhr.responseType == 'json') {
                    console.log(xhr.response);
                }
            }
        };

        xhr.upload.onload = function (e) {
            console.log(e.response);
        };

        xhr.upload.onprogress = function (e) {
            if (e.lengthComputable) {
                var percentComplete = e.loaded / e.total * 100;
                console.log(percentComplete + "%");
                progress.val(percentComplete);
            }
        };
        var formData = new FormData($('#petowner')[0]);
        xhr.send(formData);
    })
});
