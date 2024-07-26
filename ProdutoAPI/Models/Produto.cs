using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoAPI.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TipoProduto Tipo { get; set; }
        public decimal Preco { get; set; }
    }
    public enum TipoProduto
    {
        Material = 1,
        Servico = 2,
    }
}
