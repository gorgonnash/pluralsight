'use strict';

eventsApp.controller('EventController', function EventController($scope, $log, eventData, $anchorScroll, $routeParams, $route) {
    
    $scope.sortorder = 'name';

    //eventData.getEvent()
    //    .success(function (event) {
    //        $scope.event = event;
    //    })
    //    .error(function (data, status, headers, config) {
    //        $log.warn(data, status, headers, config);
    //    });

    // directly bind to resource returned
    eventData.getEventRes($routeParams.eventId)
        .$promise
        .then(function (event) { $scope.event = event; console.log(event); })
        .catch(function (response) { console.log(response); });

    // access additional route property in route definition
    console.log('foo:' + $route.current.foo);

    // additional route property in query string
    console.log('cid: ' + $route.current.params.cid);

    // reload page without reload entire application
    $scope.reload = function () {
        $route.reload();
    };

    $scope.upVoteSession = function (session) {
        session.upVoteCount++;
    };

    $scope.downVoteSession = function (session) {
        session.upVoteCount--;
    };

    $scope.scrollToSession = function () {
        $anchorScroll();
    };
});
