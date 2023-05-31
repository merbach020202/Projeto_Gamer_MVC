using Microsoft.AspNetCore.Mvc;
using ProjetoGamer_MVC.Infra;
using ProjetoGamer_MVC.Models;

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

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            //Instância de objeto equipe
            Equipe novaEquipe = new Equipe();

            //atribuição de valores recebidos do formulário
            novaEquipe.Nome = form["Nome"].ToString();

            //aqui estava chegando como string (não queremos assim)
            // nova equipe.imagem = form["imagem"].ToString

            //Início da lógica do upload de imagem
            if (form.Files.Count > 0)
            {

                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //guarda caminho completo até o caminho do arquivo(imagem - nome com extensão)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "Padrão.Png";
            }

            //adiciona objeto na tabela do BD
            c.Equipe.Add(novaEquipe);

            //salva as alterações feitas no BD
            c.SaveChanges();

            //retorna para o local chamando a rota de listar(método index)
            return LocalRedirect("~/Equipe/Listar");
        }
        //fim da lógica de upload






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}