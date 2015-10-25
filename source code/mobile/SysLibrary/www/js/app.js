// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
var app = angular.module('starter', ['ionic']);

app
.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if(window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
      cordova.plugins.Keyboard.disableScroll(true);
    }
    if(window.StatusBar) {
      StatusBar.styleLightContent();
    }
  })
  })
    .config(function($stateProvider, $urlRouterProvider){
      $stateProvider
      .state('collection',{
          url: '/collection',
          abstract: true,
          templateUrl: 'templates/tab_collection.html'
        })
        .state('collection.books', {
          url: '/books',
          views: {
            'collection-books': {
              templateUrl: 'templates/collection_books.html',
              controller: 'BookCtrl'
            }
          }
        })
        .state('collection.book-details', {
          url: '/books/:book_id',
          views:{
            'collection-books': {
              templateUrl: 'templates/collection_book_details.html',
              controller: 'BookDetailCtrl'
            }
          }
        })
        .state('collection.favorites', {
          url: '/favorites',
          views: {
            'collection-favorites': {
              templateUrl: 'templates/collection_favorites.html'
              // controller: 'BookCtrl'
            }
          }
        })
        .state('collection.account', {
          url: '/account',
          views: {
            'collection-account': {
              templateUrl: 'templates/collection_account.html'
              // controller: 'BookCtrl'
            }
          }
        });

      $urlRouterProvider.otherwise('/collection/books');
});
