using System;
using CadastroProdutoAPI.Modelos;

namespace CadastroProdutoAPI.Servicos
{
    public class ProdutoServicoAPI
    {
        public List<ProdutoAPI> lista {  get; private set; }

        public ProdutoServicoAPI()
        {
        }

        public ProdutoServicoAPI(List<ProdutoAPI> listaDeProdutos)
        {
            lista = listaDeProdutos;
        } 

        public ProdutoAPI BuscaProduto(int id)
        {
            ProdutoAPI produtoEncontrado = lista.FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado != null)
            {
                return produtoEncontrado;
            }
            else
                Console.WriteLine("Nao encontrei esse ID");
            return null;
        }
    }
}
