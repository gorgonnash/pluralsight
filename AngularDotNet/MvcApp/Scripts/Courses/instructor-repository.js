registrationModule.factory('instructorRepository', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get('/api/InstructorsV2').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    };
});