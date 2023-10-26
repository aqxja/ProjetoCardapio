using Microsoft.EntityFrameworkCore;
using ProjetoCardapio.Models;

namespace ProjetoCardapio.Models
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<ProjetoCardapio.Models.Periodo>? Periodo { get; set; }
        public DbSet<ProjetoCardapio.Models.Dias>? Dias { get; set; }
        public DbSet<ProjetoCardapio.Models.Salas>? Salas { get; set; }
        public DbSet<ProjetoCardapio.Models.Presencas>? Presencas { get; set; }
        public DbSet<ProjetoCardapio.Models.Pratos>? Pratos { get; set; }
    }
}
