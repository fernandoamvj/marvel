using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMarvel.Models
{
    public class PersonagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public List<string> Historias { get; set; }
    }
}