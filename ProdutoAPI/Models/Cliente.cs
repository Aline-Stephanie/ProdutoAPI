using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoAPI.Models
{
    [Table("clientes")]
    public class Cliente
    {
        public long Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
