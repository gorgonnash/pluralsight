'use strict';

// inject filter service, or inject single filter as '[filtername]Filter' will achieve the same
eventsApp.controller('FilterSampleController', function FilterSampleController($scope, $filter, durationsFilter) {

    $scope.data = {};

    // reference filter by name
    var durations = $filter('durations');
    console.log(durations);

    // reference injected filter directly
    $scope.data.duration1 = durationsFilter(1);
    $scope.data.duration2 = durationsFilter(2);
    $scope.data.duration3 = durationsFilter(3);
    $scope.data.duration4 = durationsFilter(4);

    console.log(durationsFilter);
});