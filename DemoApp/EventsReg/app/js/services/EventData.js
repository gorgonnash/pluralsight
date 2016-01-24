'use strict';

eventsApp.factory('eventData', function ($http, $log) {
    return {

        getEvent: function (successcb) {
            $http({method: 'GET', url: '/data/event/1'})
            .success(function (data, status, headers, config) {
                successcb(data);
            })
            .error(function (data, status, headers, config) {
                $log.warn(data, status, headers, config);
            });
        },

        event: {
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
        }
    };
});

//Common services:

//$http
//$resource

//$anchorScroll
//$cacheFactory
//$compile
//$parse
//$locale
//$timeout
//$exceptionHandler
//$filter
//$cookieStore

//$interpolate
//$log
//$rootScope
//$window
//$document
//$rootElement

//$route
//$routeParams
//$location

//$httpBackend
//$controller