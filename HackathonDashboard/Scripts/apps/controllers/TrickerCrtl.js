(function (app) {

    app.controller('trickerCrtl', trickerCrtl);

    trickerCrtl.$inject = ['$scope', '$http', 'SignalRService', '$rootScope'];

    function trickerCrtl($scope, $http, SignalRService, $rootScope) {
        $scope.show = true;
        //$scope.overallMilestoneStatus = '';
        SignalRService.register();

        function onTeamListComplete(response) {
            $scope.teamList = response.data;
            //console.log($scope.teamList);
            angular.forEach($scope.teamList, function (value, key) {
                $scope.teamList[key].overallStatus = plotOverallMilestoneStatus(value);

            });

        }

        function onTeamListError(reason) {
            $scope.eroor = "Could not fetch team list";
        }

        function plotOverallMilestoneStatus(value) {
            var NoOfMilestone = value.Milestones.length;
            var totalMilestone = 0;
            angular.forEach(value.Milestones, function (v, i) {
                totalMilestone += +v.Status;
            });

            return (totalMilestone / NoOfMilestone).toFixed(2);
        };

        function onTeamDetailComplete(r) {
            $scope.teamMilestone = r.data;
        }

        function onTeamDetailError(reason) {
            $scope.error = "Could not fetch team list";
        }

        $http.get('/api/getTeams/')
             .then(onTeamListComplete, onTeamListError);

        $scope.getSingleTeamStatus = function (team) {
            $http.get('/api/getTeam/' + team.TeamId)
                .then(onTeamDetailComplete, onTeamDetailError);

        }
        $scope.open = function () {
            $scope.showModal = true;
        };

        $scope.ok = function () {
            $scope.showModal = false;
        };

        $scope.cancel = function () {
            $scope.showModal = false;
        };

        //if (!SignalRService.listeners['broadcastUpdatedMilestone']) {
            console.log('LISTENER...');
            $scope.$on('broadcastUpdatedMilestone', function (event, args) {
               // console.log(event);
                var index = 99999;
                for (var i = 0; i < $scope.teamList.length; i++) {
                    if ($scope.teamList[i].TeamId == args.team.TeamId) {
                        index = i;
                        //console.log(index);
                    }
                }
                console.log('in teamcrtl broadcast: ', args.team);
                
                $scope.$apply(function () {
                    $scope.teamList[index].overallStatus = plotOverallMilestoneStatus(args.team);
                });
            });
            //SignalRService.listeners['broadcastUpdatedMilestone'] = true;
        //}

    }

})(angular.module('routerApp'));