registrationModule.factory('courseRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get('/api/CoursesV2').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    };
});