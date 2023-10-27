﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCardapio.Models
{
    [Table("Dias")]
    public class Dias
    {
        [Column("DiasId")]
        [Display(Name = "Id dia")]

        public int DiasId { get; set; }

        [Column("DiaNome")]
        [Display(Name = "Nome dia")]

        public string NomeDia { get; set; } = string.Empty;

    }
}
