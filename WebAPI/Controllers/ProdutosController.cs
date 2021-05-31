using Business.InterfaceProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Produto;
using Model.RetornoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProduto _IProduto;

        public ProdutosController(IProduto IProduto)
        {
            _IProduto = IProduto;
        }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            return Json(await _IProduto.List());
        }

        [HttpPost("ObterProdutoPorId")]
        public async Task<IActionResult> ObterProdutoPorId(int Id)
        {
            return Json(await _IProduto.GetEntityById(Id));
        }


        [HttpPost("AdicionarProduto")]
        public async Task<Retorno> AdicionarProduto(ProdutoViewModel produto)
        {

            var retorno = new Retorno();
            bool error = false;

            try
            {
                await _IProduto.Add(produto);

                // se ouver um erro 
                if (error)
                {
                    retorno.Sucesso = false;
                    retorno.Erros.Add(string.Concat("Email :", "Campo Obrigatório"));
                }
                else
                {
                    retorno.Sucesso = true;
                    retorno.Erros.Add(string.Concat("Tudo certo por aqui!"));
                }


            }
            catch (Exception erro)
            {

                retorno.Sucesso = false;
                retorno.Erros.Add(erro.Message);
            }

            return retorno;
        }

        [HttpPost("AtualizarProduto")]
        public async Task AtualizarProduto(ProdutoViewModel produto)
        {
            await _IProduto.Update(produto);
        }

        [HttpPost("RemoverProduto")]
        public async Task RemoverProduto(ProdutoViewModel produto)
        {
            await _IProduto.Delete(produto);
        }


    }
}
