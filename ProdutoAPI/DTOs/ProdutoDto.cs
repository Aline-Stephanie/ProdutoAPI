using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTOs
{
    public class ProdutoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "É necessário informar um preço.")]
        public decimal Preco { get; set; }
    }

    public class NovoProdutoDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "É necessário informar um preço.")]
        public decimal Preco { get; set; }
    }
}
