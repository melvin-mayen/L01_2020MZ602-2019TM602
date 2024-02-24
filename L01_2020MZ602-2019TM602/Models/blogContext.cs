using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace L01_2020MZ602_2019TM602.Models
{
    public class blogContext : DbContext
    {
        public blogContext(DbContextOptions<blogContext> options) : base(options)
        {
        }

        public DbSet<Clalificaciones> Clalificaciones { get; set; }

        public DbSet<Comentarios> Comentarios { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
