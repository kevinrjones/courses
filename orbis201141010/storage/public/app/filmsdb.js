var films = films || {};

films.indexedDB = films.indexedDB || {};

films.indexedDB.name = "FILMS";
films.indexedDB.filmObjectStore = "FILM";
films.indexedDB.quoteIndex = "IxFilmsByQuote";

films.indexedDB.open = function (filmsController) {
    version = 3;

    var request = indexedDB.open(films.indexedDB.name, version);

    request.onupgradeneeded = function (e) {
        var db = e.target.result;

        if(db.objectStoreNames.contains(films.indexedDB.filmObjectStore)){
            // save data
            db.deleteObjectStore(films.indexedDB.filmObjectStore);
        }

        db.createObjectStore(films.indexedDB.filmObjectStore, {autoIncrement: true});
    };

    request.onsuccess = function (e) {
        films.indexedDB.db = e.target.result;
            filmsController.getAllFilms();
    }
};
