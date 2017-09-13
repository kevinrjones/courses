var mandelbrot = (function (params) {

    var minX = params.minX, maxX = params.maxX,
        minY = params.minY, maxY = params.maxY,
        width = params.width, height = params.height,
        maxEscapeIterations = params.maxEscapeIterations;

    // 'distance' between colors
    var colorScale = Math.ceil(0xFFFFFF / maxEscapeIterations);
    var colorTable = new Array(maxEscapeIterations);
    var escapeValues = new Array(width * height);

    var colorValues = new Array(width * height);

    // the image ranges over an x and y extent
    // this is distance between each point that we will
    // calculate in the image
    // e.g. abs(maxX) + abs(minX) = 3
    // width == 300
    // so each point we will calculate is 3/300 apart
    // same for y
    var pointWidth = (Math.abs(maxX) + Math.abs(minX)) / width;
    var pointHeight = (Math.abs(maxY) + Math.abs(minY)) / height;

    (function initializeColorTable() {
        for (var i = 0; i < colorTable.length; i++) {
            colorTable[i] = colorScale * (i + 1);
        }
    })();

    var Bound = 4;

    function calculateIterationsToEscape(pixelX, pixelY) {
        var x = 0;
        var y = 0;

        var iteration = 0;

        while ((x * x) + (y * y) <= Bound
            && iteration < maxEscapeIterations) {
            var xTemp = (x * x) - (y * y) + pixelX;
            y = (2 * x * y) + pixelY;

            x = xTemp;

            iteration++;
        }
        return iteration;
    }

    function convertCountToColor(ndx, escapeValue) {
        if (escapeValue == maxEscapeIterations) {
            colorValues[ndx] = 0;
        }
        else {
            colorValues[ndx] = colorTable[escapeValue];
        }
        return colorValues[ndx];
    }

    function generate() {
        // set the y co-ordinate of the center of the top left pixel
        var yPixel = minY + (pointHeight / 2);
        for (var y = 0; y < height; y++) {
            // set the x co-ordinate of the center of the top left pixel
            var xPixel = minX + (pointWidth / 2);
            for (var x = 0; x < width; x++) {
                var ndx = (y * width) + x;
                escapeValues[ndx] = calculateIterationsToEscape(xPixel, yPixel);

                var c = convertCountToColor(ndx, escapeValues[ndx]);

                xPixel += pointWidth;
            }
            yPixel += pointHeight;
        }
    }

    return {
        generate: generate,
        colorData: colorValues
    }
});

