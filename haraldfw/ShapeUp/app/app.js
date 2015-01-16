'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ngRoute'
])
    .controller('SimpleController', function($scope) {
      $scope.persons = [
        {name:'John', from:'usa'},
        {name:'Harald', from:'norway'},
        {name:'Jane', from:'england'}
      ];
      $scope.addPerson = function() {
        $scope.persons.push(
            {
              name: $scope.newPerson.name,
              from: $scope.newPerson.from
            }
        );
      }
    })
    .config(function($routeProvider) {
      $routeProvider
      .when('/listView.html',
      {
        controller:'SimpleController',
        templateUrl:'listView.html'
      })
      .when('/boxView.html',
      {
        controller:'SimpleController',
        templateUrl:'boxView.html'
      })
      .otherwise({redirectTo:'/listView.html'});
});