using ProdutoAPI.Models;

namespace ProdutoAPI.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(long id);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(long id);
        Task<IEnumerable<ItemDashboard>> ObterDashboard();

    }
}
