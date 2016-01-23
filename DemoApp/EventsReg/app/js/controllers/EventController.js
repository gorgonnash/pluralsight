'use strict';

eventsApp.controller('EventController', function EventController($scope) {
    
    $scope.sortorder = 'name';
    $scope.event = {
        name: 'Angular test',
        date: '1/1/2016',
        time: '9:00 pm',
        location: {
            address: 'Somewhere',
            city: 'Redmond',
            state: 'WA'
        },
        imageUrl: '/img/angularjs-logo.png',
        sessions: [
            { name: 'Directives 101 Introductory', creatorName: 'Bob', duration: 1, level: 'Advanced', abstract: 'As you wish.', upVoteCount: 0 },
            { name: 'Scopes everything', creatorName: 'Joe', duration: 2, level: 'Introductory', abstract: 'Yesss!', upVoteCount: 0 },
            { name: 'Controllers mastery', creatorName: 'Mary', duration: 3, level: 'Intermediate', abstract: 'Pwned!', upVoteCount: 0 }
        ]
    };

    $scope.upVoteSession = function (session) {
        session.upVoteCount++;
    };

    $scope.downVoteSession = function (session) {
        session.upVoteCount--;
    };
});
