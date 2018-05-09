
var routerApp = angular.module('routerApp', ['ui.router']);

//routerApp.run(function ($rootScope, $templateCache) {
//    $rootScope.$on('$routeChangeStart', function (event, next, current) {
//        if (typeof (current) !== 'undefined') {
//            $templateCache.remove(current.templateUrl);
//        }
//    });
//});

var connection;
routerApp.run(['$rootScope', 'CurrentUserFactory', function ($rootScope, CurrentUserFactory) {
    user='';
    CurrentUserFactory.getCurrentUser()
             .then(function (data) {
                 user = data;
             }, function () {
                 console.log('could not get current user');
             });


    //$rootScope.$on('$stateChangeStart', function () {
    //    if (connection && connection.state && connection.state !==4 /* disconnected */) {
    //        console.log('signlar connection abort');
    //        connection.stop();
    //    }
    //});
}]);

routerApp.config(function ($locationProvider, $stateProvider, $urlRouterProvider) {
    $locationProvider.html5Mode(true);

    $urlRouterProvider.otherwise('/');

    $stateProvider
            .state('home', {
                url: '/home',
                views: {
                    '': {
                        templateUrl: 'Scripts/apps/views/main-home.html'
                    },
                    'tricker-details@home': {
                        templateUrl: 'Scripts/apps/views/status.html',
                        controller: 'postCrtl'
                    },
                    'trickers@home': {
                        templateUrl: 'Scripts/apps/views/team-list.html',
                        controller: 'trickerCrtl'
                    }
                }
            })
            .state('teamDetails', {
                url: '/teamDetails',
                templateUrl: 'Scripts/apps/views/team-detail.html',
                controller: 'teamCrtl'
            });

});




