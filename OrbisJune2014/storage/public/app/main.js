var films = films || {}

films.FilmsController = function ($scope) {
    var vm = this;

    films.indexedDB.open(this);

    vm.films = [];

    vm.addFilm = function (title, quote) {
        var db = films.indexedDB.db;

        var tx = db.transaction([films.indexedDB.filmObjectStore], "readwrite");

        var store = tx.objectStore(films.indexedDB.filmObjectStore);

        var request = store.put({
            title: title,
            quote: quote
        });

        request.onsuccess = function (e) {
            console.log(e);
            vm.getAllFilms();
        };

        request.onerror = function (e) {
            console.log(e);
        };
    };

    vm.getAllFilms = function () {

        vm.films = [];
        var db = films.indexedDB.db;

        var tx = db.transaction([films.indexedDB.filmObjectStore], "readwrite");

        var store = tx.objectStore(films.indexedDB.filmObjectStore);

        var keyRange = IDBKeyRange.lowerBound(0);

        var cursorRequest = store.openCursor(keyRange);

        cursorRequest.onsuccess = function (e) {
            var result = e.target.result;

            if (!!result == false) {
                return;
            }

            $scope.$apply(function () {
                vm.films.push({key: result.key, data: result.value});
            });

            result.continue();
        };

        cursorRequest.onerror = function (e) {
            console.log(e);
        }
    };

    vm.deleteFilm = function (id) {
        var db = films.indexedDB.db;
        var trans = db.transaction([films.indexedDB.filmObjectStore], "readwrite");

        var store = trans.objectStore(films.indexedDB.filmObjectStore);

        var request = store.delete(id);

        request.onsuccess = function (e) {
            vm.getAllFilms();
        };
        request.onerror = function (e) {
            console.log("failed to delete");
        };
    };

};