$(function() {
    var canvas = $('#canvas')[0];

    var ctx = canvas.getContext("2d");

    //rectangle(ctx);

    //line(ctx);

    // bezier

    ctx.font = "50px Consolas";
    ctx.strokeStyle = 'rgba(255, 0,0, 0.5)';
    ctx.strokeText("Hello world", 10, 300);

//    images(ctx, canvas);
});

function images(ctx, canvas) {
    var img = new Image();
    img.src = "Rainbow.jpg";

    img.onload = function() {
        ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
        grayScale();
    };

    function grayScale() {
        var pixels = ctx.getImageData(0, 0, canvas.width, canvas.height);

        for (var ndx = 0; ndx < pixels.data.length; ndx += 4) {
            var red = pixels.data[ndx];
            var green = pixels.data[ndx + 1];
            var blue = pixels.data[ndx + 2];
            var gray = red * 0.3 + green * 0.59 + blue * 0.11;

            pixels.data[ndx] = gray;
            pixels.data[ndx + 1] = gray;
            pixels.data[ndx + 2] = gray;
        }
        ctx.putImageData(pixels, 0, 0);
    }
}

function bezier(ctx) {
    ctx.strokeStyle = 'red';

    ctx.beginPath();
    ctx.lineWidth = 0.25;
    ctx.moveTo(50, 50);
    ctx.lineTo(50, 200);
    ctx.lineTo(200, 50);
    ctx.stroke();

    ctx.beginPath();
    ctx.strokeStyle = 'black';
    ctx.lineWidth = 2;
    ctx.bezierCurveTo(50, 50, 50, 200, 200, 50);
    ctx.stroke();

}
function line(ctx) {
    ctx.beginPath();
    ctx.strokeStyle = "#ff0000";
    ctx.lineWidth = 10;
    ctx.moveTo(10, 10);
    ctx.lineTo(100, 100);
    ctx.lineTo(20, 100);
    ctx.lineCap = "round";
    //ctx.closePath();
    ctx.stroke();

}

function rectangle(ctx) {
    ctx.fillStyle = "Orange";
    ctx.strokeStyle = "black";
    ctx.strokeRect(20, 20, 200, 100);
    ctx.fillRect(20, 20, 200, 100);


    //ctx.fillStyle = "red";
    ctx.clearRect(50, 50, 200, 100);
}