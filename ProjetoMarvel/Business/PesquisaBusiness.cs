using ProjetoMarvel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMarvel.Business
{
    public class PesquisaBusiness
    {
        public static void InserePesquisa(string texto, bool obteveRetorno)
        {
            var banco = new DbConnection();
            var pesquisa = new Pesquisa()
            {
                id = 1,
                data_hora = DateTime.Now,
                obteve_retorno = obteveRetorno,
                texto_pesquisa = texto
            };
            banco.Pesquisa.Add(pesquisa);
            banco.SaveChanges();
        }
    }
}