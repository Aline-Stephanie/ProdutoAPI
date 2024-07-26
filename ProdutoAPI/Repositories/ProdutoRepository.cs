using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.Models;

namespace ProdutoAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _dbContext;

        public ProdutoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Produto>> ObterTodos() {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterPorId(long id)
        {
            return await _dbContext.Produtos.FindAsync(id);
        }
        public async Task<IEnumerable<ItemDashboard>> ObterDashboard()
        {
            return await _dbContext.Produtos
                .GroupBy(p => p.Tipo)
                .Select(t => new ItemDashboard
                {
                    Tipo = ((TipoProduto)t.Key).ToString(),
                    Quantidade = t.Count(),
                    PrecoMedio = t.Average(p => p.Preco)
                })
                .ToListAsync();
        }

        public async Task Adicionar(Produto produto) {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Atualizar(Produto produto) {
            _dbContext.Produtos.Update(produto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Remover(long id) {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto is not null) {
                _dbContext.Produtos.Remove(produto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
