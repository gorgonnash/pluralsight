'use strict';

registrationModule.controller("CoursesController", function ($scope, courseRepository) {
    //$scope.courses = bootstrappedData.courses;

    courseRepository.get().then(function (courses) {
        $scope.courses = courses;
    });
});