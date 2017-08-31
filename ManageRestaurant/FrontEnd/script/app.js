/// <reference path="D:\Project\New folder\RestautantManagement\ManageRestaurant\FrontEnd\js/angular/angular.js" />
var app = angular.module("MyApp", ["ngRoute"]);
alert("OKE");
app.config(function ($routeProvider) {
    $routeProvider
        .when("/order", {
            templateUrl: "../../View/Order/index.html"
        })
        .when("/table", {
            templateUrl: "../../View/Table/index.html"
        })
        .when("/typeemployee", {
            templateUrl: "../../View/TypeEmployee/index.html"
        })
        .when("/blue", {
            templateUrl: "blue.htm"
        });
});