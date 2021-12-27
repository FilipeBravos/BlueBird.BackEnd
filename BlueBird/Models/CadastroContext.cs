using Microsoft.EntityFrameworkCore;

namespace Cadastro.Models
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