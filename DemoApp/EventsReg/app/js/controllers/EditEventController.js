'use strict';

eventsApp.controller('EditEventController', function EditEventController($scope, eventData) {

    $scope.saveEvent = function (event, eventForm) {
        console.log(eventForm);
        if (eventForm.$valid) {
            eventData.saveRes(event)
                .$promise.then(
                    function (response) { console.log('success', response) },
                    function (response) { console.log('failure', response) }
                );
        }
    }

    $scope.cancelEdit = function () {
        alert('event cancelled!');
        window.location = "/EventDetails.html";
    }

});