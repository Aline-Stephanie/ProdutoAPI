using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.DTOs;
using ProdutoAPI.Models;
using ProdutoAPI.Services;

namespace ProdutoAPI.Controllers
{
    [ApiController]
    [Route("/produtos")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> LeituraDeLista()
        {
            var produtos = await _produtoService.ObterTodos();
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LeituraPorID(long id)
        {
            var produto = await _produtoService.ObterPorId(id);
            if (produto is null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var dashboard = await _produtoService.ObterDashboard();
            return Ok(dashboard);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] NovoProdutoDto novoProdutoDto)
        {
            var produto = new Produto
            {
                Nome = novoProdutoDto.Nome,
                Tipo = ConverteStringParaTipoProduto(novoProdutoDto.Tipo),
                Preco = novoProdutoDto.Preco
            };
            await _produtoService.Adicionar(produto);

            return CreatedAtAction(nameof(LeituraPorID), new { id = produto.Id }, produto);
        }
        [HttpPut]
        public async Task<IActionResult> Alterar(ProdutoDto produtoDto)
        {
            var produto = await _produtoService.ObterPorId(produtoDto.Id);

            if (produto is null)
            {
                return NotFound();
            }
            produto.Nome = string.IsNullOrEmpty(produtoDto.Nome.Trim()) ? produto.Nome : produtoDto.Nome;
            produto.Tipo = string.IsNullOrEmpty(produtoDto.Tipo.Trim()) ? produto.Tipo : ConverteStringParaTipoProduto(produtoDto.Tipo);
            produto.Preco = produtoDto.Preco >= 0 ? produtoDto.Preco : produto.Preco;

            await _produtoService.Atualizar(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(long id)
        {
            await _produtoService.Remover(id);
            return NoContent();
        }

        private TipoProduto ConverteStringParaTipoProduto(string tipoStr)
        {
            return tipoStr.Replace("ç", "c").ToLower() switch
            {
                "material" => TipoProduto.Material,
                "servico" => TipoProduto.Servico,
                _ => throw new ArgumentException("Tipo de produto inválido. Escolha entre: Serviço ou Material.")
            };
        }
    }
}
