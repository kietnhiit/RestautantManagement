/// <reference path="D:\Project\New folder\RestautantManagement\ManageRestaurant\FrontEnd\js/angular/angular.js" />
app.controller('typeController', function ($scope, $http, $filter) {
    //get data
    $scope.types = [];
    $scope.type = {};
    $http.get('http://localhost:1523/api/typeofemployee').then(function (res) {
        $scope.types = res.data;
    });

    //add and update
    $scope.saveData = function () {
        // $scope.type.NameOfType = $scope.typeName;
        // if ($scope.type.TypeID == 0) {

        var params = {
            "NameOfType": $scope.typeName
        };

        $http.post("http://localhost:1523/api/typeofemployee", params).then(function (res) {
            window.location.reload();
        });
        // }
        //else {
        //    var params = {
        //        "typeid": $scope.type.typeid,
        //        "typename": $scope.typename
        //    };
        //    $http.post("http://www.saigontech.edu.vn/proshop-api/typeupdate.php?token=" + user.accesstoken, params).then(function (res) {
        //        window.location.reload();
        //        //find selected item
        //        // $scope.type = $filter('filter')($scope.types, { typeid: parseint(id) }, true)[0];
        //        // $scope.type.name = $scope.typename;
        //    });
        //}

    }
    //show modal
    $scope.showModal = function (id) {
        jQuery(function () {
            if (id == 0) {
                $("#modalTitle").text("New Type");
                $("#btnAddAction").text("Add");
            } else {
                alert(id);
                $("#modalTitle").text("Edit Type");
                $("#btnAddAction").text("Update");

                //find selected item
                $scope.type = $filter('filter')($scope.types, { TypeID: id }, true)[0];

                $scope.typeName = $scope.type.NameOfType;
            }
            $("#myModal").modal('show');
        });
    }
    alert("here");

});