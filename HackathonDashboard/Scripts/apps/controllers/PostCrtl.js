(function (app) {

    //app.value('$', $);
    //app.value('endpoint', 'http://localhost:49916');
    //app.value('hub', 'ChatHub');


    app.controller('postCrtl', postCrtl);

    postCrtl.$inject = ['$rootScope', '$scope', '$http', '$', 'endpoint', 'hub', 'CurrentUserFactory', 'SignalRService'];

    function postCrtl($rootScope, $scope, $http, $, endpoint, hub, CurrentUserFactory, SignalRService) {
        $scope.userName = '';
        $scope.message = '';
        $scope.messages = [ ];

        SignalRService.register();

        CurrentUserFactory.getCurrentUser()
             .then(function (data) {
                 $scope.userName = data.MemberName;
             }, function () {
                 console.log('could not get current user');
             });

        //if (!SignalRService.listeners['broadcastMessage']) {
            $scope.$on('broadcastMessage', function (event, args) {
                //console.log('in postcrtl broadcast: ', args.name,' ' ,args.message);
                updateMessage(args.name, args.message);
            });
          //  SignalRService.listeners['broadcastMessage'] = true;
       // }

        $scope.greeting = function () {
            SignalRService.send($scope.userName, $scope.message)
            //$scope.getDateTime = new Date();
        };

       
        function updateMessage(name, message) {
            //$('#postOwnerName').text(name);
            //$('#discussion').text(message);
            //$('#message').val('').focus();

            //$scope.messages.push(newMessage);
            $scope.messages.push({
                "name": name,
                "message": message,
                "date" : new Date()
            });

            $scope.message = '';
            $scope.$apply();
        };
    }


})(angular.module('routerApp'));