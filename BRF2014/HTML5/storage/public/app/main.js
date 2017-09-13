var films = films || {}

films.FilmsController = function ($scope) {
    var vm = this;


    films.indexedDB.open(vm);

    vm.films = [];

    vm.addFilm = function (title, quote) {
        var db = films.indexedDB.db;
        var trans = db.transaction([films.indexedDB.filmObjectStore],
            "readwrite");
        var store = trans.objectStore(films.indexedDB.filmObjectStore);

        store.put({
            title: title,
            quote: quote
        });
    };

    vm.getAllFilms = function () {

        var db = films.indexedDB.db;
        var trans = db.transaction([films.indexedDB.filmObjectStore],
            "readwrite");
        var store = trans.objectStore(films.indexedDB.filmObjectStore);
        var keyRange = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(keyRange);

        cursorRequest.onsuccess = function (e) {

            $scope.$apply(function () {
                var result = e.target.result;
                if (!!result == false) {
                    return;
                }
                // result.value holds the value returned
                vm.films.push({data: result.value});
                result.continue();
            });
        };

        cursorRequest.onerror = function(e){
            console.log(e);
        }
    };

    vm.deleteFilm = function(id){
    };

};