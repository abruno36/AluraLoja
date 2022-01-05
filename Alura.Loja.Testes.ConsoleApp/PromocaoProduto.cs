namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
