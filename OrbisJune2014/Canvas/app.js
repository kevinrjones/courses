// pacman


$(function () {

    var canvas = $('#canvas')[0];

    var ctx = canvas.getContext('2d');

    rotator(ctx);
});

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
    ctx.bezierCurveTo(50, 50, 50, 200, 200, 50)
    ctx.stroke();

}

function pacman(ctx) {
    roundedRect(ctx, 12, 12, 185, 175, 15);
    roundedRect(ctx, 19, 19, 170, 160, 9);
    roundedRect(ctx, 53, 53, 49, 33, 10);
    roundedRect(ctx, 53, 119, 49, 16, 6);
    roundedRect(ctx, 135, 53, 49, 33, 10);
    roundedRect(ctx, 135, 119, 25, 49, 10);

    pacman(ctx);

    for (var i = 0; i < 8; i++) {
        ctx.fillRect(51 + i * 16, 35, 4, 4);
    }

    for (i = 0; i < 6; i++) {
        ctx.fillRect(115, 51 + i * 16, 4, 4);
    }

    for (i = 0; i < 8; i++) {
        ctx.fillRect(51 + i * 16, 99, 4, 4);
    }

    ghost(ctx);

    // A utility function to draw a rectangle with rounded corners.

    function roundedRect(ctx, x, y, width, height, radius) {
        ctx.beginPath();
        ctx.moveTo(x, y + radius);
        ctx.lineTo(x, y + height - radius);
        ctx.quadraticCurveTo(x, y + height, x + radius, y + height);
        ctx.lineTo(x + width - radius, y + height);
        ctx.quadraticCurveTo(x + width, y + height, x + width, y + height - radius);
        ctx.lineTo(x + width, y + radius);
        ctx.quadraticCurveTo(x + width, y, x + width - radius, y);
        ctx.lineTo(x + radius, y);
        ctx.quadraticCurveTo(x, y, x, y + radius);
        ctx.stroke();
    }

    function pacman(ctx) {
        ctx.beginPath();
        ctx.arc(37, 37, 13, Math.PI / 7, -Math.PI / 7, false);
        ctx.lineTo(31, 37);
        ctx.fill();
    }

    function ghost(ctx) {
        ctx.beginPath();
        ctx.moveTo(83, 116);
        ctx.lineTo(83, 102);
        ctx.bezierCurveTo(83, 94, 89, 88, 97, 88);
        ctx.bezierCurveTo(105, 88, 111, 94, 111, 102);
        ctx.lineTo(111, 116);
        ctx.lineTo(106.333, 111.333);
        ctx.lineTo(101.666, 116);
        ctx.lineTo(97, 111.333);
        ctx.lineTo(92.333, 116);
        ctx.lineTo(87.666, 111.333);
        ctx.lineTo(83, 116);
        ctx.fill();

        ctx.fillStyle = "white";
        ctx.beginPath();
        ctx.moveTo(91, 96);
        ctx.bezierCurveTo(88, 96, 87, 99, 87, 101);
        ctx.bezierCurveTo(87, 103, 88, 106, 91, 106);
        ctx.bezierCurveTo(94, 106, 95, 103, 95, 101);
        ctx.bezierCurveTo(95, 99, 94, 96, 91, 96);
        ctx.moveTo(103, 96);
        ctx.bezierCurveTo(100, 96, 99, 99, 99, 101);
        ctx.bezierCurveTo(99, 103, 100, 106, 103, 106);
        ctx.bezierCurveTo(106, 106, 107, 103, 107, 101);
        ctx.bezierCurveTo(107, 99, 106, 96, 103, 96);
        ctx.fill();

        ctx.fillStyle = "black";
        ctx.beginPath();
        ctx.arc(101, 102, 2, 0, Math.PI * 2, true);
        ctx.fill();

        ctx.beginPath();
        ctx.arc(89, 102, 2, 0, Math.PI * 2, true);
        ctx.fill();
    }
}

function mm(ctx) {

    var widthCanvas = 400;
    var footRadius = 50;
    var earRadius = 40;
    var bodyRadius = 60;
    var noseRadius = 15;
    var eyeRadius = 10;
    var tongueRadius = 10;

    var canvas = $('#canvas')[0];

    var ctx = canvas.getContext('2d');

//    ctx.strokeStyle = 'black';
//
//    ctx.shadowColor = '#999';
//    ctx.shadowBlur = 20;
//    ctx.shadowOffsetX = 15;
//    ctx.shadowOffsetY = 15;
//
//    ctx.fillRect(10, 10, 200, 100);
//    ctx.strokeRect(10, 10, 250, 350);

    ctx.shadowColor = '';
    ctx.shadowBlur = 0;
    ctx.shadowOffsetX = 0;
    ctx.shadowOffsetY = 0;

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'yellow';
    ctx.arc(widthCanvas - footRadius, widthCanvas - footRadius, footRadius, 0, 2*Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'yellow';
    ctx.arc(widthCanvas - 4 * footRadius, widthCanvas - 2 * footRadius, footRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas / 2 + 60, earRadius, earRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - 210, earRadius + 50, earRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'goldenrod';
    ctx.arc(widthCanvas / 2 + 72, (footRadius * 3) - 21, footRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'red';
    ctx.arc(widthCanvas - bodyRadius, 220, bodyRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - noseRadius - 40, 120, noseRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - eyeRadius - 110, 100, eyeRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - eyeRadius - 80, 100, eyeRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'red';
    ctx.arc(widthCanvas / 2 + 72, 180, tongueRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - bodyRadius, 220, eyeRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();

    ctx.beginPath();
    ctx.fillStyle = ctx.strokeStyle = 'black';
    ctx.arc(widthCanvas - bodyRadius + 30, 200, eyeRadius, 0, 2 * Math.PI);
    ctx.fill();
    ctx.stroke();
}

function linearGradient(ctx) {
    var centerX = canvas.width / 2;

    var gradient = ctx.createLinearGradient(0, 0, 200, 250);
    //var gradient = ctx.createLinearGradient(centerX, 0, 200, 250);
    ctx.beginPath();
    gradient.addColorStop(0, '#fff');
    gradient.addColorStop(1, '#88bfe8');
    ctx.fillStyle = gradient;
    ctx.fillRect(20, 20, 200, 250);
    ctx.closePath();

}

function radialGradient(ctx) {
    var centerX = canvas.width / 2;
    var centerY = canvas.height / 2;

    var gradient = ctx.createRadialGradient(
            centerX - 30, centerY - 30, 5,
            centerX - 30, centerY - 30, 120);
    ctx.beginPath();
    gradient.addColorStop(0, '#fff');
    gradient.addColorStop(1, '#88bfe8');
    ctx.fillStyle = gradient;

    ctx.arc(centerX, centerY, 120, 0, 2 * Math.PI, true);
    ctx.fill();
    ctx.closePath();

}

function rotator(ctx) {
    var rotateBtn = $('#rotate');

    var rotateAmount = Math.PI / 36;

    rotateBtn.click(function () {
        draw(rotateAmount);
    });

    ctx.translate(500, 200);

    var draw = function (rotate) {
        var prices = [100, 90, 10, 30, 35, 60, 110]
        prices = prices.reverse();
        var width = 50;
        var gap = 10;
        var x = gap;

        // clear - set the identity transform
        // then clear and restore
        ctx.save();
        ctx.setTransform(1, 0, 0, 1, 0, 0);
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.restore();

        ctx.rotate(rotate);
        for (var ndx = 0; ndx < prices.length; ndx++) {
            ctx.fillStyle = 'red';
            var height = prices[ndx];
            ctx.fillRect(x, 0, width, height);

            ctx.beginPath();
            ctx.fillStyle = 'blue';
            ctx.arc(x + width / 2, height, 5, 0, 2 * Math.PI, false);
            ctx.fill();
            ctx.stroke();

            x += width + gap;
        }
    };
    draw(Math.PI);

}