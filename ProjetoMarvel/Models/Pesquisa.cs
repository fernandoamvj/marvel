namespace ProjetoMarvel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pesquisa")]
    public partial class Pesquisa
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string texto_pesquisa { get; set; }

        public DateTime data_hora { get; set; }

        public bool obteve_retorno { get; set; }
    }
}
