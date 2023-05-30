using Microsoft.EntityFrameworkCore;
using ProjetoGamer_MVC.Models;

namespace ProjetoGamer_MVC.Infra
{
    public class Context : DbContext
    {
        public Context()
        {           
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string de conexão com o banco
                //Data Source : é o nome do servidor do gerenciador do banco
                //Initial catalog : o nome do banco de dados

                //Autenticação pelo windows
                //Integraated Security : Autenticação pelo windows
                //TrustServerCertificate : Autenticação pelo windows

                //Autenticação pelo SqlServer
                //User Id = "nome do seu usuario de login"
                //pwd = "senha do seu usuario"

                optionsBuilder.UseSqlServer("Data Source = NOTE17-S14; Initial catalog = gamerManha; User Id = sa; pwd =Senai@134; TrustServerCertificate = true");
            }
        }
        //referências de classes e tabelas
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
    }
}
