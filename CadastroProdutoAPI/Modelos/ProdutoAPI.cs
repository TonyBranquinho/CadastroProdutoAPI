namespace CadastroProdutoAPI.Modelos
{
    public class ProdutoAPI
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public ProdutoAPI()
        {
        }

        public ProdutoAPI(int id, string nome, double preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return string.Format("{0,-4} {1,-20} {2,-10}R$ {3,-4}",
                Id, Nome, Preco, Quantidade);
        }
    }
}
