using ProdutoAPI.Models;
using ProdutoAPI.Repositories;

namespace ProdutoAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) { 
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task<Produto> ObterPorId(long id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<ItemDashboard>> ObterDashboard()
        {
            return await _produtoRepository.ObterDashboard();
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
        }

        public async Task Remover(long id)
        {
            await _produtoRepository.Remover(id);
        }
    }
}
