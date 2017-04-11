'use strict';
//app.controller('appController', ['$scope', function ($scope) {
//    $scope.starRating = 3;
//}]);


var app = angular.module("app", []);
app.controller("appController", function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
});