(function ()
{
    'use strict';

    angular.module('app').service('ProdutoService', ProdutoService);

    ProdutoService.$inject = ['Apis', '$http', '$sessionStorage']

    function ProdutoService(Apis, $http, $sessionStorage) {
        this.ObterProdutos = ObterProdutos;

        function ObterProdutos() {
            var url = Apis.url + '/produto';
            return $http.get(url, { headers: { 'Authorization': 'Bearer ' + $sessionStorage.token } });
        }
    }

})();