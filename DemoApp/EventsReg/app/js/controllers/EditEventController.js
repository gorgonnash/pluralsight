'use strict';

eventsApp.controller('EditEventController', function EditEventController($scope) {

    $scope.saveEvent = function (event, eventForm) {
        console.log(eventForm);
        if (eventForm.$valid) {
            alert('event ' + event.name + ' saved!');
        }
    }

    $scope.cancelEdit = function () {
        alert('event cancelled!');
        window.location = "/EventDetails.html";
    }

});