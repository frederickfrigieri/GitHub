using FCamara.FrederickFrigieri.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCamara.FrederickFrigieri.DS.Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        [Authorize()]
        public IHttpActionResult Get()
        {
            var produtos = _produtoService.ObterTodos();

            return Ok(produtos);
        }
    }
}
