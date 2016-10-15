
angular.module('G-Nation.controllers', [])

.controller('AuthCtrl', function($scope, $ionicConfig) {

})

// APP
.controller('AppCtrl', function($scope, $ionicConfig) {

})
.controller('loginController', function ($scope, $location, authService,$resource, $cookieStore,localStorageService,authInterceptorService,$http,$state) {
 var serviceBase = 'http://172.20.10.2:18080/tag-web/rest/users/member/social';
 $scope.sign = function () {
         $state.go('auth.signup');

    }
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function ($state) {

        authService.login($scope.loginData).then(function (response) {

    //$state.go('app.profile');
$scope.authentication = authService.authentication;
var user =window.localStorage.getItem('ls.connectedUser'); 
    $scope.cnt=JSON.parse(user);
 
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

    $scope.authExternalProvider = function (provider) {

        var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';

        var externalProviderUrl = serviceBase + "api/Account/ExternalLogin?provider=" + provider
                                                                    + "&response_type=token&client_id=" + serviceBase.clientId
                                                                    + "&redirect_uri=" + redirectUri;
        window.$windowScope = $scope;

        var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
    };

    $scope.authCompletedCB = function (fragment) {

        $scope.$apply(function () {

            if (fragment.haslocalaccount == 'False') {

                authService.logOut();

                authService.externalAuthData = {
                    provider: fragment.provider,
                    userName: fragment.external_user_name,
                    externalAccessToken: fragment.external_access_token
                };

                $location.path('/associate');

            }
            else {
                //Obtain access token and redirect to orders
                var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                authService.obtainAccessToken(externalData).then(function (response) {

    $state.go('app.profile');

                },
             function (err) {
                 $scope.message = err.error_description;
             });
            }

        });
    }
     //google authentication // FB Auth
$scope.fbLogin = function () {
        FB.login(function (response) {
            if (response.authResponse) {
                getUserInfo();
            } else {
            }
        }, {scope: 'email,user_photos,user_videos'});

        function getUserInfo() {
            // get basic info
            FB.api('/me', function (response) {
                // get profile picture
                FB.api('/me/picture?type=normal', function (picResponse) {
                    response.imageUrl = picResponse.data.url;
                    //Save user
                    var userResource=$resource("http://localhost:18080/tag-web/rest/users/member/social");
         var User = new userResource({
                    username :response.name,
                   mail : 'ameni.jmaiel@esprit.tn',   
             socialAuth:'2',
				   image_link : picResponse.data.url});
                    User.$save();
                                        $rootScope.connectedUser = User;

                    $cookieStore.put('userInfo', User);
                    $state.go('app.feeds-categories');
                    
                });
            });
        }
    };

    
 //google authentication
 $scope.gplusLogin = function () {
        var myParams = {
            // Replace client id with yours
            'clientid': '667051559939-pu1h6ibq07kbadrqi8ahg53vj2lmprvl.apps.googleusercontent.com',
            'cookiepolicy': 'single_host_origin',
            'apikey':'7YOwaSyGtLJURcDSUkSeu5mh',
            'callback': loginCallback,
            'approvalprompt': 'force',
            'scope': 'https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/plus.profile.emails.read'
        };
        gapi.auth.signIn(myParams);

        function loginCallback(result) {
            if (result['status']['signed_in']) {
                var request = gapi.client.plus.people.get({'userId': 'me'});
    request.execute(function (resp) {
                    var userEmail;
                    if (resp['emails']) {
                        for (var i = 0; i < resp['emails'].length; i++) {
                            if (resp['emails'][i]['type'] == 'account') {
                                userEmail = resp['emails'][i]['value'];
                            }
                        }
                    }
                    // store data to DB
          var userResource=$resource("http://localhost:18080/tag-web/rest/users/member/social");
         var User = new userResource({
                    username : resp.displayName,
                    mail : userEmail,  
             firstName:resp.name.givenName,
             lastName:resp.name.familyName,
             image_link : resp.image.url,
             socialAuth:'2',
             role : 'Member'
                    });
                    User.$save();
					$rootScope.connectedUser = User;
                    $cookieStore.put('userInfo', User);
                    $state.go('app.feeds-categories');
                });
            }
        }
    };

    
})

.controller('signupController', function ($scope, $location, $timeout, authService,$state,$ionicPopup) {
    
    $scope.showAlert = function($title, $message) {
        var alertPopup = $ionicPopup.alert({
            title: $title,
            template: $message
        });
    }
    $scope.savedSuccessfully = false;
   
    $scope.registration = {
        FirstName:"",
        lastName:"",
        email:"",
        picture:"",
        userName: "",
        password: "",
        confirmPassword: ""
    };

    $scope.signUp = function () {

        authService.saveRegistration($scope.registration).then(function (response) {

$scope.savedSuccessfully = true;                 $scope.showAlert('Sign up with Success, '+ $scope.registration.userName+'.','Please proceed to login');   
$state.go('auth.login');

         
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

   
 
})

.controller('profileController', function ($scope, $location, authService,localStorageService,$window,$rootScope,$state,$ionicActionSheet) {
    $scope.logOut = function () {
        
		// Show the action sheet
		var hideSheet = $ionicActionSheet.show({
			//Here you can add some more buttons
			// buttons: [
			// { text: '<b>Share</b> This' },
			// { text: 'Move' }
			// ],
			destructiveText: 'Logout',
			titleText: 'Are you sure you want to logout? This app is awsome so I recommend you to stay.',
			cancelText: 'Cancel',
			cancel: function() {
				// add cancel code..
			},
			buttonClicked: function(index) {
				//Called when one of the non-destructive buttons is clicked,
				//with the index of the button that was clicked and the button object.
				//Return true to close the action sheet, or false to keep it opened.
				return true;
			},
			destructiveButtonClicked: function(){
				//Called when the destructive button is clicked.
				//Return true to close the action sheet, or false to keep it opened.
				$state.go('auth.walkthrough');
			}
		});
                authService.logOut();


    };
$scope.authentication = authService.authentication;
var user =window.localStorage.getItem('ls.connectedUser'); 
    $scope.cnt=JSON.parse(user);
    console.log($scope.cnt);

})
//LOGIN
/*.controller('LoginCtrl', function($scope, $state, $templateCache, $q, $rootScope, $resource, $ionicPopup, $cookieStore) {
    // FB Auth
$scope.fbLogin = function () {
        FB.login(function (response) {
            if (response.authResponse) {
                getUserInfo();
            } else {
            }
        }, {scope: 'email,user_photos,user_videos'});

        function getUserInfo() {
            // get basic info
            FB.api('/me', function (response) {
                // get profile picture
                FB.api('/me/picture?type=normal', function (picResponse) {
                    response.imageUrl = picResponse.data.url;
                    //Save user
                    var userResource=$resource("http://localhost:18080/tag-web/rest/users/member/social");
         var User = new userResource({
                    username :response.name,
                   mail : 'ameni.jmaiel@esprit.tn',                                 
				   image_link : picResponse.data.url});
                    User.$save();
                                        $rootScope.connectedUser = User;

                    $cookieStore.put('userInfo', User);
                    $state.go('app.feeds-categories');
                    
                });
            });
        }
    };

    
 //google authentication
 $scope.gplusLogin = function () {
        var myParams = {
            // Replace client id with yours
            'clientid': '667051559939-pu1h6ibq07kbadrqi8ahg53vj2lmprvl.apps.googleusercontent.com',
            'cookiepolicy': 'single_host_origin',
            'apikey':'7YOwaSyGtLJURcDSUkSeu5mh',
            'callback': loginCallback,
            'approvalprompt': 'force',
            'scope': 'https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/plus.profile.emails.read'
        };
        gapi.auth.signIn(myParams);

        function loginCallback(result) {
            if (result['status']['signed_in']) {
                var request = gapi.client.plus.people.get({'userId': 'me'});
    request.execute(function (resp) {
                    var userEmail;
                    if (resp['emails']) {
                        for (var i = 0; i < resp['emails'].length; i++) {
                            if (resp['emails'][i]['type'] == 'account') {
                                userEmail = resp['emails'][i]['value'];
                            }
                        }
                    }
                    // store data to DB
          var userResource=$resource("http://localhost:18080/tag-web/rest/users/member/social");
         var User = new userResource({
                    username : resp.displayName,
                    mail : userEmail,  
             firstName:resp.name.givenName,
             lastName:resp.name.familyName,
             image_link : resp.image.url,
             role : 'Member'
                    });
                    User.$save();
					$rootScope.connectedUser = User;
                    $cookieStore.put('userInfo', User);
                    $state.go('app.feeds-categories');
                });
            }
        }
    };
//
    $scope.data = {};
    $scope.showAlert = function($title, $message) {
        var alertPopup = $ionicPopup.alert({
            title: $title,
            template: $message
        });
    }
 $scope.doLogIn = function(){     
         var authResource = $resource('http://localhost:18080/tag-web/rest/users/:username/:password');
        data = authResource.get({username:$scope.data.username,password:$scope.data.password}, function (response) {
            if(response.idUser) {
                $rootScope.connectedUser = response;
               
            } else {
                $scope.showAlert('Incorrect Credentials','Verify Your Username and Password');   
                 $state.go("auth.login");
            }
        },
        function (errorResponse) {
        });
     } 
 })*/
              
 
 /*$rootScope= {};
$rootScope.check.id= data.idUser;
var id=$rootScope.check.id;
    alert(id);*/
 


.controller('SignupCtrl', function($scope, $state, $templateCache, $q, $rootScope, $resource, $ionicPopup) {
$scope.showAlert = function($title, $message) {
        var alertPopup = $ionicPopup.alert({
            title: $title,
            template: $message
        });}
	$scope.doSignUp = function(){
        var userResource=$resource("http://localhost:18080/tag-web/rest/users/member");
         var User = new userResource({
    firstName:$scope.user.first,
    lastName:$scope.user.last,
    mail:$scope.user.email,
    password:$scope.user.password,
    username:$scope.user.username,
    image_link:"../img/avatar.jpg"});
        User.$save();
        $scope.showAlert('Sign up with Success, '+ $scope.user.username+'.','Please proceed to login');   
          $state.go('auth.login');

	}
})

.controller('ProfileCtrl', function($scope, $state, $templateCache, $rootScope, $resource, $ionicPopup,$rootScope) {
    
})

.controller('ForgotPasswordCtrl', function($scope, $state,$http) {
	$scope.recoverPassword = function(){
         var url="http://localhost:18080/tag-web/rest/users";
var username =$scope.username;
$http.get(url+'/'+username);
        
}
})

.controller('RecoverCtrl', function($scope, $state,$http,$ionicPopup,$rootScope) {
    $scope.data={};
$scope.showAlert = function($title, $message) {
        var alertPopup = $ionicPopup.alert({
            title: $title,
            template: $message
        });
    }
	$scope.recoverAccount = function(){
       var url="http://localhost:18080/tag-web/rest/users/account";
                   var password=$scope.password;
var user = $rootScope.connectedUser;
        var success=function (response){
                user = response.data;
               
          
        }
            var failure=function(err){
                $scope.showAlert('Incorrect Credentials','Verify Your Password');   
                 $state.go("auth.login");
                $scope.message=err.data.message;
            }
                   $http.get(url+'/'+password).then(success,failure);

        }


})

.controller('MapsCtrl', function($scope, $ionicLoading, $stateParams) {

    $scope.adresse=$stateParams.adresse;
	$scope.info_position = {
		lat: $stateParams.latitude,
		lng: $stateParams.longitude
	};

	$scope.center_position = {
		lat: $stateParams.latitude,
		lng: $stateParams.longitude
	};

	$scope.my_location = "";

	$scope.$on('mapInitialized', function(event, map) {
		$scope.map = map;
	});

	$scope.centerOnMe= function(){

		$scope.positions = [];

		$ionicLoading.show({
			template: 'Loading...'
		});

		// with this function you can get the user’s current position
		// we use this plugin: https://github.com/apache/cordova-plugin-geolocation/
		navigator.geolocation.getCurrentPosition(function(position) {
			var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
			$scope.current_position = {lat: pos.G,lng: pos.K};
			$scope.my_location = pos.G+", "+pos.K;
			$scope.map.setCenter(pos);
			$ionicLoading.hide();
		});
	};
})


// FEED
//brings all feed categories
.controller('FeedsCategoriesCtrl', function($scope, $http) {
	$scope.feeds_categories = [];

	$http.get('feeds-categories.json').success(function(response) {
		$scope.feeds_categories = response;
	});
})

//bring specific category providers
.controller('CategoryFeedsCtrl', function($scope, $http, $stateParams) {
	$scope.category_sources = [];

	$scope.categoryId = $stateParams.categoryId;

	$http.get('feeds-categories.json').success(function(response) {
		var category = _.find(response, {id: $scope.categoryId});
		$scope.categoryTitle = category.title;
		$scope.category_sources = category.feed_sources;
	});
})

//this method brings posts for a source provider
.controller('FeedEntriesCtrl', function($scope, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService) {
	$scope.feed = [];

	var categoryId = $stateParams.categoryId,
			sourceId = $stateParams.sourceId;

	$scope.doRefresh = function() {

		$http.get('feeds-categories.json').success(function(response) {

			$ionicLoading.show({
				template: 'Loading entries...'
			});

			var category = _.find(response, {id: categoryId }),
					source = _.find(category.feed_sources, {id: sourceId });

			$scope.sourceTitle = source.title;

			FeedList.get(source.url)
			.then(function (result) {
				$scope.feed = result.feed;
				$ionicLoading.hide();
				$scope.$broadcast('scroll.refreshComplete');
			}, function (reason) {
				$ionicLoading.hide();
				$scope.$broadcast('scroll.refreshComplete');
			});
		});
	};

	$scope.doRefresh();

	$scope.bookmarkPost = function(post){
		$ionicLoading.show({ template: 'Post Saved!', noBackdrop: true, duration: 1000 });
		BookMarkService.bookmarkFeedPost(post);
	};
})




//5edmet Mehdi

.controller('EventsFeedsCtrl', function($scope,$http){
        var url="http://localhost:18080/tag-web/rest/events";
        var success= function(response){
            $scope.numLimit = 30;
            $scope.events=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url).then(success,failure);
    
})

.controller('EventEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService,$ionicPopup,$rootScope) {
    
	var idEvent = $stateParams.eventId;
    var EventResource=$resource('http://localhost:18080/tag-web/rest/events/:id');

    $scope.event=EventResource.get({id:idEvent});
        
    $scope.reservation = function() {
     var confirmPopup = $ionicPopup.confirm({
       title: 'Make a reservation',
       template: 'Are you sure you want to make a reservation for this event?'
     });
     confirmPopup.then(function(res) {
       if(res) {
           
        var EventResource=$resource('http://localhost:18080/tag-web/rest/events/reserve',{idEvent:idEvent,idUser:$rootScope.connectedUser.idUser});

    EventResource.save();
        
     var alertPopup = $ionicPopup.alert({
       title: 'Make a reservation',
       template: 'Reservation made successfully, check your email.'
     });
     alertPopup.then(function(res) {
         
     });
   
       
       } else {
           
       }
     }
                       );
    }
})

.controller('TournamentsLiveCtrl', function($scope,$resource, $stateParams, $http, FeedList, $sce, $ionicLoading, BookMarkService){
    var idTournament = $stateParams.tournamentId;
    
    
    var TournamentResource=$resource('http://localhost:18080/tag-web/rest/tournaments/:id');

    $scope.tournament=TournamentResource.get({id:idTournament});
    
    $scope.trustSrc = function(video) {
        return $sce.trustAsResourceUrl(video);  
	}

})

.controller('AllTournamentsFeedsCtrl', function($scope,$http){
        var url="http://localhost:18080/tag-web/rest/tournaments";
        var success= function(response){
            
            $scope.tournaments=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url).then(success,failure);
    
})

.controller('TournamentsFeedsCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService) {
    
	var idEvent = $stateParams.eventId;
    
    var url="http://localhost:18080/tag-web/rest/events/eventTournaments";
        var success= function(response){
            
            $scope.tournaments=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url+"/"+idEvent).then(success,failure);
})

.controller('TournamentEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService,$ionicPopup,$rootScope) {
    
	var idTournament = $stateParams.tournamentId;
    var TournamentResource=$resource('http://localhost:18080/tag-web/rest/tournaments/:id');

    $scope.tournament=TournamentResource.get({id:idTournament});
    
    
    $scope.reservation = function() {
     var confirmPopup = $ionicPopup.confirm({
       title: 'Make a reservation',
       template: 'Are you sure you want to make a reservation for this tournament?'
     });
     confirmPopup.then(function(res) {
       if(res) {
           
        var TournamentResource=$resource('http://localhost:18080/tag-web/rest/tournaments/reserve',{idTournament:idTournament,idUser:$rootScope.connectedUser.idUser});
    
    TournamentResource.save();
        
     var alertPopup = $ionicPopup.alert({
       title: 'Make a reservation',
       template: 'Reservation made successfully, check your email.'
     });
     alertPopup.then(function(res) {
         
     });
   
       
       } else {
           
       }
     }
                       );
    }
})

.controller('LiveCtrl', function($sce,$scope,$http){
        var url="http://localhost:18080/tag-web/rest/tournaments";
        var success= function(response){
            $scope.tournaments=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url).then(success,failure);
    
     $scope.trustSrc = function(video) {
        return $sce.trustAsResourceUrl(video);  
	}
    
})

//5edmet Ameni

//ameni ALL Games
.controller('GamesFeedsCtrl', function($scope, $http) {
	
    var AllGames="http://localhost:18080/tag-web/rest/Games/games";
     
    var success= function(response){
            
            $scope.games=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    
    $http.get(AllGames).then(success,failure);

    
    
    
    
    
    
    
    
    
    
	
})







//BestGames


.controller('BestGamesFeedsCtrl', function($scope, $http) {
	
    var AllBestGames="http://localhost:18080/tag-web/rest/Games/bestRanked";
     
    var success= function(response){
            
            $scope.games=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    
    $http.get(AllBestGames).then(success,failure);

	
})

.controller('NewsGamesFeedsCtrl', function($scope, $http) {
	
    var AllnewsGames="http://localhost:18080/tag-web/rest/News";
     
    var success= function(response){
            
            $scope.news=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    
    $http.get(AllnewsGames).then(success,failure);

	
})




//ameni
.controller('CommentEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService,$rootScope, $state)
            {
      var idGame = $stateParams.gameId;
     var user = $rootScope.connectedUser;  
    
    var comments={};
     var url="http://localhost:18080/tag-web/rest/Games/Comments";
        var success= function(response){
            
            $scope.comments=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url+"/"+idGame).then(success,failure);
    
     $scope.doComment = function(){   
        
         var CommentResource=$resource('http://localhost:18080/tag-web/rest/Games/CommmOnGames',{idArticle:idGame,                                                                   idUser:user.idUser,                                                             Discrip:$scope.com});
    CommentResource.save();
          $http.get(url+"/"+idGame).then(success,failure);
    }
    
    
    
    
})


.controller('CommentnewsEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService,$rootScope,$state,$window)
            {
      var idGame = $stateParams.gameId;
       var user = $rootScope.connectedUser.idUser;  
   
    var comments={};
     var 
     url="http://localhost:18080/tag-web/rest/News/CommentsNews";
        var success= function(response){
            
            $scope.comments=response.data;
            $scope.message="found";
        }
    var failure=function(err){
        $scope.message=err.data.message;
            
    }
    
    $http.get(url+"/"+idGame).then(success,failure);
    
    
    
     $scope.doCommentNews = function(){   
        
         var CommentResource=$resource('http://localhost:18080/tag-web/rest/News/Commentaire',{idArticle:idGame,
    idUser:user,                                                                            description:$scope.com});
    CommentResource.save();
      //$state.go('app.Newws-feeds');
         $http.get(url+"/"+idGame).then(success,failure);
       
}   
    
    
    
}) 


.controller('getRating', function($scope, $state, $templateCache, $q, $rootScope, $resource, $ionicPopup,$stateParams){
    
    var GameResource=$resource('http://localhost:18080/tag-web/rest/Games/:idArticle');

    $scope.article=GameResource.get({idArticle:idGame},function(response){  
        
        $rootScope.vote=response.rating;
   
        
    
   }); 
    
    var idGame = $stateParams.gameId;
     
  
})




//ameni Game Info
.controller('GamesEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService,$rootScope,$state,$timeout) {
    var user = $rootScope.connectedUser;
	var idGame = $stateParams.gameId;
    
    var rating = $stateParams.gameRating;

     $scope.ratingsObject = {
    iconOn : 'ion-ios-star',
    iconOff : 'ion-ios-star-outline',
    iconOnColor: 'rgb(255, 201, 0)',
    iconOffColor:  'rgb(138, 138, 138)',
    rating: 2,
    minRating: 1,
    readOnly: false,
    callback: function(rating) {
      $scope.ratingsCallback(rating);
    }
  };
     $scope.MyratingsObject = {
    iconOn : 'ion-ios-star',
    iconOff : 'ion-ios-star-outline',
    iconOnColor: 'rgb(255, 201, 0)',
    iconOffColor:  'rgb(138, 138, 138)',
    rating: rating,
    minRating: 1,
    readOnly: true,
    callback: function(rating) {
      $scope.ratingsCallback(rating);   
    }
         
     
       
  };
    
    var GameResource=$resource('http://localhost:18080/tag-web/rest/Games/:idArticle');
$scope.vote="1";
    
    $scope.article=GameResource.get({idArticle:idGame},function(response){
    var data = $scope.article;
       $rootScope.vote=response.rating;

   
        
        
    var idd=$stateParams.gameTd;
    var rates=null;
     
     
    
     $scope.ratingsCallback = function(rating,$timeout) {
         
var RateResource=$resource('http://localhost:18080/tag-web/rest/Games/RateGames',{idUser:user.idUser,idArticle:idGame,rate:rating});
    $scope.doRate = function(){      
     RateResource.save();
    $state.go('app.games-feeds');
          
     };
     }
    });
      
    
    
   
  
    
    

})








//ameni news info
.controller('NewsEntriesCtrl', function($scope,$resource, $stateParams, $http, FeedList, $q, $ionicLoading, BookMarkService) {
    
	var idNews = $stateParams.gameId;
    
    var NewsResource=$resource('http://localhost:18080/tag-web/rest/News/news/:id');

    $scope.news=NewsResource.get({id:idNews});
   
      

})

;
