var app = angular.module('G-Nation',
['ngRoute',
'ngResource',
 'LocalStorageModule',
 'angular-loading-bar',
'G-Nation.controllers',
'G-Nation.factories',
   'ngCookies'

]);

app.config(function ($routeProvider) {
/*

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "index.html"
    });
*/

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "views/authentication/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "views/authentication/signup.html"
    });

      $routeProvider.when("/profile", {
        controller: "profileController",
        templateUrl: "views/app/profile.html"
    });


    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "views/authentication/refresh.html"
    });

   
    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "views/authentication/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });

});

//var serviceBase = 'https://localhost:44300/';
//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
/*
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});
*/

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


