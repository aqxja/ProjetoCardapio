using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCardapio.Models
{
    [Table("Periodo")]
    public class Periodo

    {
        [Column("PeriodoId")]
        [Display(Name = "Id do Periodo")]

        public int id { get; set; }

        [Column("PeriodoNome")]
        [Display(Name = "Nome do Periodo")]
        
        public string NomePeriodo { get; set; } = string.Empty;
    }
}
