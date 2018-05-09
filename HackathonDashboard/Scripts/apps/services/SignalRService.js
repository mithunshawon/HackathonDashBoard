(function (app) {

    app.value('$', $);
    app.value('endpoint', 'http://localhost:49916');
    app.value('hub', 'ChatHub');

    app.factory('SignalRService', SignalRService);

    function SignalRService($rootScope) {
        var hub = null;
        var _listeners = {};
        function _registerHub() {
            //console.log($rootScope);
           hub= $.connection.chatHub;
            //console.log(hub);
            // Declare a function on the chat hub so the server can invoke it
            hub.client.broadcastMessage = function (n,m) {
                $rootScope.$broadcast("broadcastMessage", {name:n,message:m});

            };

            hub.client.broadcastUpdatedMilestone = function (t) {
                $rootScope.$broadcast('broadcastUpdatedMilestone', {team:t})
            };
            // Start the connection
            $.connection.hub.start().done(function () {
                $rootScope.$broadcast("copen", { success: true });
            });
        }
        return {
            listeners:_listeners,
            register:_registerHub,
            send: function (name, message) {
                hub.server.send(name, message);
            },
            sendUpdatedMilestone: function (team) {
                hub.server.sendUpdatedMilestone(team);
            }
        }
    }

})(angular.module('routerApp'));