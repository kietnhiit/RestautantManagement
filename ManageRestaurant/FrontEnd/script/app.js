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
        .when("/green", {
            templateUrl: "green.htm"
        })
        .when("/blue", {
            templateUrl: "blue.htm"
        });
});