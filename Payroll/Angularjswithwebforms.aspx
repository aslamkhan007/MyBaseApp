﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Angularjswithwebforms.aspx.cs" Inherits="Payroll_Angularjswithwebforms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
--%>

<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script src="jquery-1.11.3.js" type="text/javascript"></script>

<%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
<%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />--%>
<%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />--%>
<%--<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.5/angular.js"></script>--%>
<script src="angular.js" type="text/javascript"></script>  
<script type="text/javascript">
    var app = angular.module('MyApp', []);
    app.controller('MyController', function ($scope, $http, $window) {
        $scope.ButtonText = "Add";
        GetCustomers($scope);
        $scope.Add = function () {
            var obj = {};
            obj.id = $scope.Id == undefined ? 0 : $scope.Id;
            obj.name = $scope.Name;
            obj.country = $scope.Country;
            $.ajax({
                url: 'Angularjswithwebforms.aspx/AddUpdateCustomer',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(obj),
                success: function (response) {
                    GetCustomers($scope);
                    $scope.Id = "";
                    $scope.Name = "";
                    $scope.Country = "";
                    $scope.ButtonText = "Add";
                },
                error: function (err) {
                    alert(response.responseText);
                }
            });
        }

        $scope.Delete = function (id) {
            var obj = {};
            obj.id = id;
            $.ajax({
                url: 'Angularjswithwebforms.aspx/DeleteCustomer',
                type: "POST",
                contentType: 'application/json',
                data: JSON.stringify(obj),
                success: function (response) {
                    GetCustomers($scope);
                },
                error: function (err) {
                    alert(response.responseText);
                }
            });
        }

        $scope.Edit = function (id) {
            var customers = $scope.Customers;
            customers.map(function (customer) {
                if (customer.Id == id) {
                    $scope.Id = customer.Id;
                    $scope.Name = customer.Name;
                    $scope.Country = customer.Country;
                    $scope.ButtonText = "Update";
                }
            });
        }
    });
    function GetCustomers($scope) {
        debugger;
        $.ajax({
            url: 'Angularjswithwebforms.aspx/GetCustomers',
            type: "POST",
            contentType: 'application/json',
            success: function (response) {
                $scope.Customers = response.d;
                $scope.$apply();
            },
            error: function (err) {               
                alert(err.responseText);
            }
        });
    }      
</script>
<div ng-app="MyApp" ng-controller="MyController">
    <div class="container">
        <div class="row">
            <table class="table">
                <tr>
                    <td>Name</td>
                    <td>
                        <input type="hidden" ng-model="Id" />
                        <input type="text" id="txtName" class="form-control" name="name" ng-model="Name" />
                    </td>
                </tr>
                <tr>
                    <td>Country</td>
                    <td><input type="text" id="txtCountry" class="form-control" name="country" ng-model="Country" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <button type="button" id="btnInsert" class="btn btn-primary" ng-click="Add()">{{ButtonText}}</button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <table class="table table-striped table-bordered table-condensed">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Country</th>
                        <th>Edit | Delete</th>
                    </tr>
                </thead>
                <tbody ng-repeat="customer in Customers">
                    <tr>
                        <td>{{customer.Id}}</td>
                        <td>{{customer.Name}}</td>
                        <td>{{customer.Country}}</td>
                        <td>
                            <button type="button" id="btnEdit" class="btn btn-primary" ng-click="Edit(customer.Id)"><i class="fa fa-edit"></i></button>
                            <button type="button" id="btnDelete" class="btn btn-primary" ng-click="Delete(customer.Id)"><i class="fa fa-trash-o"></i></button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
</body>

</html>
