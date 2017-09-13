var films = films || {};

films.indexedDB = films.indexedDB || {};

films.indexedDB.name = "FILMS";
films.indexedDB.filmObjectStore = "FILM";
films.indexedDB.quoteIndex = "IxFilmsByQuote";

films.indexedDB.open = function (filmsController) {

    var version = 1;

    var request = indexedDB.open(films.indexedDB.name, version);

    request.onupgradeneeded = function(e){
        console.log("upgrading...");
        var db = e.target.result;

        if(db.objectStoreNames.contains(films.indexedDB.filmObjectStore)){
            db.deleteObjectStore(films.indexedDB.filmObjectStore);
        }

        var result = db.createObjectStore(films.indexedDB.filmObjectStore, {autoIncrement: true});
        result.onsuccess = function(e){
            console.log("Store created");
        };

        result.onerror = function(e){
            console.log("Store not created")
        };
    };

    request.onsuccess = function(e){
        films.indexedDB.db = e.target.result;
        filmsController.getAllFilms();
    };

    request.onerror = function(e){
        console.log(e);
    }

};
