using Microsoft.AspNetCore.Mvc;
using ProjetoGamer_MVC.Infra;

namespace ProjetoGamer_MVC.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        //Instância do contexto para acessar o banco de dados
        Context c = new Context();

        [Route("Listar")] //https://localhost//Equipe/Listar
        public IActionResult Index()
        {
            //variável que armazena as equipes listadas do banco
            ViewBag.Equipe = c.Equipe.ToList();
            //retorna a view de equipe (TELA)
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}