using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCardapio.Models
{
    [Table("Presencas")]
    public class Presencas
    {
        [Column("PresencaId")]
        [Display (Name = "Id da Presenca")]

        public int Id { get; set; }

        [ForeignKey( "SalasId" ) ]

        public int SalasId { get;set; }

        public Salas Salas { get; set;}



        [Column("QuantidadeAlunos")]
        [Display(Name = "Quantidade de Alunos")]

        public int QuantidadeAlunos { get; set;}



    }
}
