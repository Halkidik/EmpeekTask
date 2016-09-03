app.service("APIService", function ($http,$q) {
    this.getInformation = function () {
        var url = 'api/Home';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    this.getFiles = function (path) {
        return $http({
            method: 'post',
            data: path,
            url: 'api/Home'
        });
    }
    var deferredAbort = $q.defer();
    this.getCount = function (path) {
        return $http({
            method: 'post',
            data: path,
            url: 'api/Home/Counter',
            timeout: deferredAbort.promise
        });
    }
    this.abort = function(){
        deferredAbort.resolve();
        deferredAbort = $q.defer();
    }

});

