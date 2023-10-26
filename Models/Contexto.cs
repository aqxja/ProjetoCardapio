using Microsoft.EntityFrameworkCore;

namespace ProjetoCardapio.Models
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
