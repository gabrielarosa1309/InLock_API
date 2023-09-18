using Microsoft.EntityFrameworkCore;
using webApi.inlock.codeFirst.manha.Domains;

namespace webApi.inlock.codeFirst.manha.Contexts
{
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Define as opções de construção do banco (String Conexão)
        /// </summary>
        /// <param name="optionsBuilder"> Objeto com as configurações definidas </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE04-S15; Database=inlock_games_codeFirst_manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
