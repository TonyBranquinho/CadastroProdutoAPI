using System;
using CadastroProdutoAPI.Servicos;
using CadastroProdutoAPI.Modelos;
using System.Text.Json;

namespace CadastroProdutoAPI.Dados
{
    internal class OperacaoBancoDados
    {
        // METODO QUE CARREGA OS DADOS JSON EM UMA LISTA
        public static List<ProdutoAPI> Carregar()
        {
            // Le o arquivo JSON e o armazena na variavel CONTEUDO
            string conteudo = File.ReadAllText("BancoDeDadosJson.json");

            // Iguinora letras maiusculas e minusculas
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Converte o conteudo JSON em uma lista do tipo PRODUTO
            return JsonSerializer.Deserialize<List<ProdutoAPI>>(conteudo, options);
        }


        // METODO QUE SALVA O CONTEUDO DA LISTA NO ARQUIVO JSON
        public static void Salvar(List<ProdutoAPI> listaDeProdutosAPI)
        {
            // Converte a lista de produtos em texto JSON
            string conteudo = JsonSerializer.Serialize(listaDeProdutosAPI);

            // Atualiza o arquivo json com conteudo convertido da lista
            File.WriteAllText("BancoDeDadosJson.json", conteudo);
        }
    }
}
