app.controller('APIController', function ($scope, APIService) {
    getStart();
    var search = null;

    function getStart() {
        var servCall = APIService.getInformation();
        servCall.then(function (d) {
            $scope.currentFiles = d;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.')
        });
    }
    $scope.saveSubs = function ($event) {
        var path = {
            folder: $event.currentTarget.innerText,
            path: $scope.currentPath
        };
        var saveSubs = APIService.getFiles(path);
        saveSubs.then(function (result) {
            $scope.currentPath = result.data.currentPath;
            $scope.currentFiles = result.data.currentFiles;
            $scope.dots = result.data.Dots;
            $scope.isFile = result.data.isFile;
            if (search)
                APIService.abort();

            if ($scope.dots && $scope.isFile) {
                search = APIService.getCount()
                $scope.count = ["Waiting", "Waiting", "Waiting"];
                search.then(function (result1) {
                    console.log(result1.data)
                    $scope.count = result1.data;

                })
            }
            if(!$scope.dots)
                $scope.count = ["", "", ""];
            
            console.log("sssss");
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };
});