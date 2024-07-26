using ProdutoAPI.Models;

namespace ProdutoAPI.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(long id);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(long id);
        Task<IEnumerable<ItemDashboard>> ObterDashboard();
    }
}
