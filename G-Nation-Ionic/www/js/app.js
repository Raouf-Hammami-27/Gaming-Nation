// Ionic Starter App

angular.module('underscore', [])
.factory('_', function() {
  return window._; // assumes underscore has already been loaded on the page
});

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
angular.module('G-Nation', [
  'ionic',
  'angularMoment',
  'G-Nation.controllers',
  'G-Nation.directives',
  'G-Nation.filters',
  'G-Nation.services',
  'G-Nation.factories',
  'G-Nation.config',
  'G-Nation.views',
  'underscore',
  'ionic-ratings',
  'ngMap',
  'ngResource',
  'ngCordova',
  'slugifier',
  'ionic.contrib.ui.tinderCards',
  'youtube-embed',
  'ngCookies',
'LocalStorageModule',

])

.run(function($ionicPlatform, PushNotificationsService, $rootScope, $ionicConfig, $timeout) {

  $ionicPlatform.on("deviceready", function(){
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if(window.cordova && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
    }
    if(window.StatusBar) {
      StatusBar.styleDefault();
    }

    PushNotificationsService.register();
  });

  // This fixes transitions for transparent background views
  $rootScope.$on("$stateChangeStart", function(event, toState, toParams, fromState, fromParams){
    if(toState.name.indexOf('auth.walkthrough') > -1)
    {
      // set transitions to android to avoid weird visual effect in the walkthrough transitions
      $timeout(function(){
        $ionicConfig.views.transition('android');
        $ionicConfig.views.swipeBackEnabled(false);
      	console.log("setting transition to android and disabling swipe back");
      }, 0);
    }
  });
  $rootScope.$on("$stateChangeSuccess", function(event, toState, toParams, fromState, fromParams){
    if(toState.name.indexOf('app.feeds-categories') > -1)
    {
      // Restore platform default transition. We are just hardcoding android transitions to auth views.
      $ionicConfig.views.transition('platform');
      // If it's ios, then enable swipe back again
      if(ionic.Platform.isIOS())
      {
        $ionicConfig.views.swipeBackEnabled(true);
      }
    	console.log("enabling swipe back and restoring transition to platform default", $ionicConfig.views.transition());
    }
  });

  $ionicPlatform.on("resume", function(){
    PushNotificationsService.register();
  });

})

.config(function($stateProvider, $urlRouterProvider, $ionicConfigProvider) {
  $stateProvider

  //INTRO
  .state('auth', {
    url: "/auth",
    templateUrl: "views/auth/auth.html",
    abstract: true,
    controller: 'AuthCtrl'
  })

  .state('auth.walkthrough', {
    url: '/walkthrough',
    templateUrl: "views/auth/walkthrough.html"
  })

  .state('auth.login', {
    url: '/login',
    templateUrl: "views/auth/login.html",
    controller: 'loginController'
  })

  .state('auth.signup', {
    url: '/signup',
    templateUrl: "views/auth/signup.html",
    controller: 'signupController'
  })

  .state('auth.forgot-password', {
    url: "/forgot-password",
    templateUrl: "views/auth/forgot-password.html",
    controller: 'ForgotPasswordCtrl'
  })
 .state('auth.recover', {
    url: "/recover-account",
    templateUrl: "views/auth/recover.html",
    controller: 'RecoverCtrl'
  })

  .state('app', {
    url: "/app",
    abstract: true,
    templateUrl: "views/app/side-menu.html",
    controller: 'AppCtrl'
  })


  

  //FEEDS
  //5edmet raouf
  .state('app.feeds-categories', {
    url: "/feeds-categories/:idUser",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/feeds-categories.html",
        controller: 'FeedsCategoriesCtrl'
      }
    }
  })

  .state('app.category-feeds', {
    url: "/category-feeds/:categoryId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/category-feeds.html",
        controller: 'CategoryFeedsCtrl'
      }
    }
  })

  .state('app.feed-entries', {
    url: "/feed-entries/:categoryId/:sourceId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/feed-entries.html",
        controller: 'FeedEntriesCtrl'
      }
    }
  })

 

  //OTHERS
  .state('app.settings', {
    url: "/settings",
    views: {
      'menuContent': {
        templateUrl: "views/app/settings.html",
        controller: 'SettingsCtrl'
      }
    }
  })

  .state('app.forms', {
    url: "/forms",
    views: {
      'menuContent': {
        templateUrl: "views/app/forms.html"
      }
    }
  })

  .state('app.profile', {
    url: "/profile",
    views: {
      'menuContent': {
        templateUrl: "views/app/profile.html",
        controller: 'profileController'

      }
    }
  })

  .state('app.bookmarks', {
    url: "/bookmarks",
    views: {
      'menuContent': {
        templateUrl: "views/app/bookmarks.html",
        controller: 'BookMarksCtrl'
      }
    }
  })
  
  //5edmet Mehdi
  
  .state('app.events-feeds', {
    url: "/category-feeds/events",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/events-feeds.html",
        controller: 'EventsFeedsCtrl'
      }
    }
  })
  
   .state('app.events-reserve', {
    url: "/category-feeds/events/reserve/:eventId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/events-reserve.html",
        controller: 'EventsReserveCtrl'
      }
    }
  })
  
  .state('app.event-info', {
    url: "/event-info/:eventId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/event-info.html",
        controller: 'EventEntriesCtrl'
      }
    }
  })
  
  .state('app.tournaments-feeds', {
    url: "/category-feeds/tournaments/:eventId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/tournaments-feeds.html",
        controller: 'TournamentsFeedsCtrl'
      }
    }
  })
  .state('app.tournament-live', {
    url: "/category-feeds/tournament/live/:tournamentId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/tournaments-live.html",
        controller: 'TournamentsLiveCtrl'
      }
    }
  })
  .state('app.alltournaments-feeds', {
    url: "/category-feeds/tournaments",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/alltournaments-feeds.html",
        controller: 'AllTournamentsFeedsCtrl'
      }
    }
  })

  .state('app.tournament-info', {
    url: "/event-info/:tournamentId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/tournament-info.html",
        controller: 'TournamentEntriesCtrl'
      }
    }
  })
  
  
  //5edmet Ameni
  
   //tous les jeux
   .state('app.games-feeds', {
    url: "/category-feeds/games/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/games-feeds.html",
        controller: 'GamesFeedsCtrl'
      }
    }
  })
  
  
   //best Ranked 
   .state('app.Bestgames-feeds', {
    url: "/category-feeds/games",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/Bestgames-feeds.html",
        controller: 'BestGamesFeedsCtrl'
      }
    }
  })
  
     //ALL News
   .state('app.Newws-feeds', {
    url: "/category-feeds/News",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/NewsArticle-feeds.html",
        controller: 'NewsGamesFeedsCtrl'
      }
    }
  })
  
  
  
  .state('app.game-info', {
    url: "/game-info/:gameId/:gameRating",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/game-info.html",
        controller: 'GamesEntriesCtrl'
      }
    }
  })
  
  
  .state('app.news-info', {
    url: "/news-info/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/news-info.html",
        controller: 'NewsEntriesCtrl'
      }
    }
  })
  
  
  .state('app.comments-feeds', {
    url: "/category-feeds/comments/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/comm-info.html",
        controller: 'CommentEntriesCtrl'
      }
    }
  })
  
  
    .state('app.commentsNews-feeds', {
    url: "/category-feeds/comments/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/commNews-info.html",
        controller: 'CommentnewsEntriesCtrl'
      }
    }
  })
  
  
   .state('app.CommentOn-Article', {
    url: "/category-feeds/commenOn/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/comment.html",
        controller: 'CommentOnArticleCtrl'
      }
    }
  })
  
  .state('app.rate-Article', {
    url: "/category-feeds/rate/:gameId",
    views: {
      'menuContent': {
        templateUrl: "views/app/feeds/game-info.html",
        controller: 'ControllerName'
      }
    }
  })

;

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/auth/walkthrough');
})
.run(['authService', function (authService) {
    authService.fillAuthData();
}])
/*.config(['$httpProvider',function ($httpProvider) {

 $httpProvider.defaults.useXDomain = true;
 delete $httpProvider.defaults.headers.common["X-Requested-With"];
 $httpProvider.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
 $httpProvider.defaults.headers.common["Accept"] = "application/json";
 $httpProvider.defaults.headers.common["content-type"] = "application/json";

}])*/
;
