(function (app) {

    app.factory('CurrentUserFactory', CurrentUserFactory);

   function CurrentUserFactory($http) {
        var service = {};

        service.getCurrentUser = function () {
            return $http.get('/api/getCurrentUser')
                    .then(function (result) {
                        return result.data;
                    });
        };

        return service;
    }

})(angular.module('routerApp'));