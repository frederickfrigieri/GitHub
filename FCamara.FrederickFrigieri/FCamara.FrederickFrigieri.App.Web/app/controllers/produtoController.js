(function () {
    'use strict';

    angular.module('app').controller('ProdutoController', ProdutoController);

    ProdutoController.$inject = ['$scope', 'ProdutoService'];

    function ProdutoController($scope, ProdutoService) {
        $scope.produtos = [];
        $scope.messageError = '';
        $scope.carregarProdutos = carregarProdutos;

        function carregarProdutos() {
            $scope.produtos = [];

            ProdutoService.ObterProdutos().success(function (data) {
                data.forEach(function (item) {
                    $scope.produtos.push(new ProdutoViewModel(item.codigo, item.nome,
                        item.descricao, item.preco));
                });
            }).error(function (data) {
                console.log(data);
                $scope.messageError = data.message;
            });
        }
    }

    function ProdutoViewModel(id, nome, descricao, preco) {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;
        this.preco = preco;
    }

})();