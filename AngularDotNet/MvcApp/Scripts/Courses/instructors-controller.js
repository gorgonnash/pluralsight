registrationModule.controller("InstructorsController", function ($scope, bootstrappedInstructors) {
    $scope.instructors = bootstrappedInstructors.instructors;
});