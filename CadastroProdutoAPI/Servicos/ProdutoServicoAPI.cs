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

        // Metodo para Cadastro de novos produtos
        public void Cadastrar(ProdutoAPI novoProduto)
        {
            lista.Add(novoProduto);
        }

        // Metodo que verifica item pelo ID
        public bool VerificaId(int id)
        {
            return !lista.Any(u => u.Id == id); // True se NAO existir
        }
    }
}
