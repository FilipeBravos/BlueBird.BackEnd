using Microsoft.EntityFrameworkCore;

namespace BlueBird.Models
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options)
            : base(options)
        {
        }

        public DbSet<Cadastro> Cadastro { get; set; }
    }
}