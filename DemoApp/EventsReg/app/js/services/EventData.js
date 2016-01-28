'use strict';

eventsApp.factory('eventData', function ($http, $resource) {

    var resource = $resource('/data/event/:id', { id: '@id' },
        { "getAll": { method: "GET", isArray: true, params: { something: "foo" } } });

    return {
        getEvent: function () {
            return $http({
                method: 'GET', url: '/data/event/1'
            })
        },

        // GET from RESTful API
        getEventRes: function (eventId) {
            return resource.get({id: eventId});
        },

        saveRes: function (event) {
            event.id = 999;     // hard code id here
            return resource.save(event);
        },

        getAllEvents: function () {
            //return [resource.get({ id: 1 })];
            //return resource.get({ id: null });
            return resource.query();
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