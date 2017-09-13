var films = films || {}

films.FilmsController = function ($scope) {
    var vm = this;


    films.indexedDB.open(vm);

    vm.films = [];

    vm.addFilm = function (title, quote) {
        var db = films.indexedDB.db;
        var trans = db.transaction([films.indexedDB.filmObjectStore], "readwrite")
        var store = trans.objectStore(films.indexedDB.filmObjectStore);

        var request = store.put({title: title, quote: quote});

        request.onsuccess = function(e) {
            vm.getAllFilms();
        }
    };

    vm.getAllFilms = function () {
        var db = films.indexedDB.db;
        var trans = db.transaction([films.indexedDB.filmObjectStore], "readwrite")
        var store = trans.objectStore(films.indexedDB.filmObjectStore);

        var key = IDBKeyRange.lowerBound(0);
        var cursorRequest = store.openCursor(key);

        vm.films = [];

        cursorRequest.onsuccess = function (e) {
            $scope.$apply(function () {
                var result = e.target.result;

                if(result == null){
                    return;
                }

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