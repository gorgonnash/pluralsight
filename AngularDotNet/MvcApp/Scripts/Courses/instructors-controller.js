'use strict';

registrationModule.controller("InstructorsController", function ($scope, instructorRepository) {
    //$scope.instructors = bootstrappedData.instructors;

    instructorRepository.get().then(function (instructors) {
        $scope.instructors = instructors;
    });
});