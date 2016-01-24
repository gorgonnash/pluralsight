'use strict';

eventsApp.controller('CookieStoreSampleController', function CookieStoreSampleController($scope, $cookieStore) {

    $scope.event = { id: 1, name: "My Event" };

    $scope.saveEventToCookies = function (evt) {
        $cookieStore.put('event', evt);     // cannot set exp date for now
    };

    $scope.getEventFromCookies = function () {
        console.log($cookieStore.get('event'));
    };

    $scope.removeEventFromCookies = function () {
        $cookieStore.remove('event');
    };
});