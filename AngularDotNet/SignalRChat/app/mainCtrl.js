angular.module('app').controller('mainCtrl', function ($scope, chat) {
    $scope.messages = [];

    $scope.inRoom = false;
    $scope.nameSet = false;

    $scope.setName = function () {
        $scope.nameSet = true;
    };

    $scope.joinRoom = function () {
        $scope.inRoom = true;
        chat.server.joinRoom($scope.roomName);
    };

    $scope.leaveRoom = function () {
        $scope.inRoom = false;
        chat.server.leaveRoom($scope.roomName);
    };

    $scope.sendMessage = function () {
        chat.server.sendMessage({ message: $scope.newMessage, roomName: $scope.roomName, name: $scope.name });
        $scope.newMessage = "";
    }

    chat.client.newMessage = function onNewMessage(message) {
        $scope.messages.push({ message: message });
        $scope.$apply();
        console.log(message);
    };
});