'use strict';

var eventsApp = angular.module('eventsApp', ['ngResource', 'ngCookies', 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider.when('/newEvent', 
        {
            templateUrl: 'templates/NewEvent.html',
            controller: 'EditEventController'
        });
        $routeProvider.when('/events',
        {
            templateUrl: 'templates/EventList.html',
            controller: 'EventListController'
        });
        $routeProvider.when('/event/:eventId',
        {
            templateUrl: 'templates/EventDetails.html',
            controller: 'EventController'
        });
    })
    .factory('myCache', function ($cacheFactory) {
        return $cacheFactory('myCache', {capacity:3});
    });



