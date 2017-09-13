var kevin = {
    name: "Kevin"
}

function show() {
    console.log("Name is " + this.name);
}

kevin.show = show;

$('#clickme').click(kevin.show.bind(kevin));