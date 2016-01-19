'use strict';

eventsApp.controller('EventController', function EventController($scope) {
    
    $scope.event = {
        name: 'Angular test',
        date: '1/1/2016',
        time: '9:00 pm'
    };
});
