'use strict';

eventsApp.controller('TimeoutSampleController', function TimeoutSampleController($scope, $timeout) {

    console.log($timeout);

    // binding changes due to timeout handler will be tracked by angular, but setTimeout will not have the same effect
    var promise = $timeout(function () {
        $scope.name = "John Doe";
    }, 3000);

    $scope.cancel = function () {
        $timeout.cancel(promise);
        console.log('Cancelled!');
    };

});