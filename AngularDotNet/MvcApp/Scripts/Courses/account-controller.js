'use strict';

registrationModule.controller("AccountController", function ($scope, accountRepository, $location) {
    $scope.save = function (student) {
        $scope.error = false;
        $scope.errors = [];
        accountRepository.save(student).then(
            function () { $location.url('Registration/Courses'); },
            function () {
                $scope.error = true;
            });
    };
});