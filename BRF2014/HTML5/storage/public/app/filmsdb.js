var films = films || {};

films.indexedDB = films.indexedDB || {};

films.indexedDB.name = "FILMS";
films.indexedDB.filmObjectStore = "FILM";
films.indexedDB.quoteIndex = "IxFilmsByQuote";

films.indexedDB.open = function (filmsController) {
    var version = 2;
    var request = indexedDB.open(films.indexedDB.name, version);

    request.onupgradeneeded = function (e) {
        var db = e.target.result; // IDBDatabase

        if (db.objectStoreNames.contains(films.indexedDB.filmObjectStore)) {
            db.deleteObjectStore(films.indexedDB.filmObjectStore);
        }

        var store = db.createObjectStore(films.indexedDB.filmObjectStore,
            { autoIncrement: true });

    };

    request.onsuccess = function (e) {
        films.indexedDB.db = e.target.result;
        filmsController.getAllFilms();
    }

};
