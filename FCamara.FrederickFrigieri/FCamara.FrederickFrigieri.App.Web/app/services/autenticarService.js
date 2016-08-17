(function () {
    'use strict';

    angular.module('app').service('AutenticarService', AutenticarService);

    AutenticarService.$inject = ['Apis', '$http'];

    function AutenticarService(Apis, $http) {
        this.Autenticar = Autenticar;

        function Autenticar() {
            var authurl = Apis.url + '/security/token';
            var data = "grant_type=password&username=fred&password=fcamara";

            return $http.post(authurl,data,
                { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
        }
    }

})();