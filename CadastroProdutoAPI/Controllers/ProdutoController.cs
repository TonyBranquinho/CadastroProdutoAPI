using Microsoft.AspNetCore.Mvc; // Importa atributos e tipos relacionados a API
using CadastroProdutoAPI.Servicos;
using CadastroProdutoAPI.Dados;
using CadastroProdutoAPI.Modelos;

namespace CadastroProdutoAPI.Controllers
{
    [ApiController] // Diz que essa classe é um controlador de API
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

        [HttpGet] // Diz que esse metodo responde a requisiçao GET (sem parametro)
        public ActionResult<List<ProdutoAPI>> GetTodos()
        {
            return _servicoAPI.lista;
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoAPI> GetPorId(int id)
        {
            var buscaId = _servicoAPI.BuscaProduto(id);

            if (buscaId == null)
                return NotFound();

            return buscaId;
        }
    }
}
