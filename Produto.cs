namespace ExemploCRUD
{
    public class Produto
    {
        public int Id{ get; set; }
        public string NomeProduto{ get; set; }
        public string Descricao{ get; set; }
        public int IdCategoria{ get; set; }
        public double Preco{ get; set; }
        public Produto()
        {
        }

        public Produto(string NomeProduto, string Descricao, int IdCategoria, double Preco)
        {
            this.NomeProduto = NomeProduto;
            this.Descricao = Descricao;
            this.IdCategoria = IdCategoria;
            this.Preco = Preco;
        }
    }
}