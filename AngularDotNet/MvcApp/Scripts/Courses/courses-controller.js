registrationModule.controller("CoursesController", function ($scope, bootstrappedCourses) {
    $scope.courses = bootstrappedCourses.courses;
});