using Microsoft.AspNetCore.Mvc; // Importa atributos e tipos relacionados a API
using CadastroProdutoAPI.Servicos;
using CadastroProdutoAPI.Dados;
using CadastroProdutoAPI.Modelos;

namespace CadastroProdutoAPI.Controllers
{
    [ApiController] // Diz que essa classe é um controlador de APIm  
    [Route("[controller]")] // Define o nome da classe como rota 


    public class ProdutoController : ControllerBase // Classe base para controlador de API
    {

        // Campo privado/ atribuido somente uma vez/ tipo campo / nome do campo
        private readonly ProdutoServicoAPI _servicoAPI;

        public ProdutoController() // Metodo construtor
        {
            var lista = OperacaoBancoDados.Carregar(); // le o JSON
            _servicoAPI = new ProdutoServicoAPI(lista); // cria o serviço com essa lista
        }


        [HttpGet] // Diz ao ASP.NET Core que esse metodo responde a requisiçao GET - BUSCA
        public ActionResult<List<ProdutoAPI>> GetTodos()
        {
            return _servicoAPI.lista;
        }


        [HttpGet("{id}")] // Diz ao ASP.NET Core que esse metodo responde a requisiçao GET - BUSCA ID
        public ActionResult<ProdutoAPI> GetPorId(int id)
        {
            var buscaId = _servicoAPI.BuscaProduto(id);

            if (buscaId == null)
                return NotFound();

            return buscaId;
        }


        [HttpPost] // Diz ao ASP.NET Core que esse metodo responde a requisiçoes POST - CADASTRA
        public ActionResult<ProdutoAPI> Cadastrar([FromBody] ProdutoAPI novoProduto) // Metodo que retona o novo objeto
        {
            int id = novoProduto.Id;

            // Verifica se o ID ja existe na lista
            bool idDisponivel = _servicoAPI.VerificaId(id);
            if (!idDisponivel)
                return Conflict("ID ja existente. Escolha outro.");

            // Adiciona o novo produto na lista
            _servicoAPI.Cadastrar(novoProduto);

            // Salva a lista atualizada no JSON
            OperacaoBancoDados.Salvar(_servicoAPI.lista);

            // Retorna o novo produto com status 201 Created
            return CreatedAtAction(nameof(GetPorId), new { id = novoProduto.Id }, novoProduto);
        }


        [HttpPut("{id}")] // Diz ao ASP.NET Coreque esse metodo responde a requisiçoes PUT - ATUALIZA
        public ActionResult Atualizar(int id, [FromBody] ProdutoAPI produtoAtualizado)
        {
            // Verifica se tem esse ID na lista e atribui o retorno a essa nova variavel
            var produtoExistente = _servicoAPI.BuscaProduto(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            // Atualiza os dados do produto encontrado
            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Quantidade = produtoAtualizado.Quantidade;

            // Salva no arquivo JSON
            OperacaoBancoDados.Salvar(_servicoAPI.lista);

            return NoContent(); // Retorna 204 - indica atualizaçao feita com sucesso
        }


        [HttpDelete("{id}")] // Diz ao ASP.NET Core que esse metodo responde a requisiçao DELETE - REMOVE      
        public ActionResult Delete(int id) // Metodo para deletar itens
        {
            // Verifica se tem esse ID na lista e atribui o retorno a essa nova variavel
            var produtoDeletar = _servicoAPI.BuscaProduto(id);
            if (produtoDeletar == null)
            {
                return NotFound(id);
            }

            _servicoAPI.lista.Remove(produtoDeletar); // Deleta o produto da lista
            
            OperacaoBancoDados.Salvar(_servicoAPI.lista); // Salva a nova lista JSON

            return NoContent(); // Retorna 204 - Exclusao feita com sucesso
        }
    }
}
