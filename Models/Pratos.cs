using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCardapio.Models
{
    [Table("Pratos")]
    public class Pratos
    {
        [Column("PratoId")]
        [Display( Name = "Codigo do Prato" ) ]

        public int Id { get; set; }

        [ForeignKey( "PeriodoId")]
        public int PeriodoId { get; set; }

        public Periodo? Periodo { get; set; }

        [ForeignKey("DiasId")]
        public int DiasId { get; set; }

        public Dias? Dias { get; set; }

        [Column("PratoNome")]
        [Display(Name = "Nome do Prato")]
        public string PratoNome { get; set; } = string.Empty;

        [Column("LinkImagem")]
        [Display(Name = "Digite o Link da Imagem")]

        public string LinkImagem { get; set; } = string.Empty;
    }
}
