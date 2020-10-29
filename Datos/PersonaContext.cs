using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class PersonaContext : DbContext
    {
        public PersonaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}