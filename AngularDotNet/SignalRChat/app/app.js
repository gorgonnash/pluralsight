﻿(function () {
    angular.module('app', []);

    $(function () {
        $.connection.hub.logging = true;
        $.connection.hub.start();
    });

    $.connection.hub.error(function (err) {
        console.log('an error occurred: ' + err);
    });

    angular.module('app').value('chat', $.connection.chat);
})();