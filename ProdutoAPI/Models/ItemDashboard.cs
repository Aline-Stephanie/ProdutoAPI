namespace ProdutoAPI.Models
{
    public class ItemDashboard
    {
        public string Tipo { get; set; } = string.Empty;
        public long Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
    }
}
