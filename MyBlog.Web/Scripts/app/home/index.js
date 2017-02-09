var app = angular.module('indexApp', []);
app.controller('indexCtr', ['$scope',function ($scope) {
    $scope.aa = function () {
        alert("111");
    };
}]);