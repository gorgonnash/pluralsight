'use strict';

// overwrite angular $exceptionHandler service
eventsApp.factory('$exceptionHandler', function () {
    return function (exception) {
        console.log("exception handled: " + exception.message);
    };
});