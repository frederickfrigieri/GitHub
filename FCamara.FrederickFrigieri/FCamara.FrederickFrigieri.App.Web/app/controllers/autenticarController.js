(function () {
    'use strict';

    angular.module('app')
        .controller('AutenticarControler', AutenticarControler);

    AutenticarControler.$inject = ['$scope', 'AutenticarService', '$sessionStorage'];

    function AutenticarControler($scope, AutenticarService, $sessionStorage) {
        $scope.token = '';
        $scope.expire = '';

        $scope.GerarToken = GerarToken;

        function GerarToken() {
            AutenticarService.Autenticar().success(function (data) {
                console.log(data);

                $sessionStorage.token = data.access_token;

                $scope.token = $sessionStorage.token;
                $scope.expire = data.expires_in;
            });
        }
    }

})();