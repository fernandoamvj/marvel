using Newtonsoft.Json;
using ProjetoMarvel.Business;
using ProjetoMarvel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMarvel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }

        public ActionResult Pesquisa(string textoPesquisa)
        {
            PersonagemDTO personagem;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = "68bda7a37b1e938b8653b8fd0082043d";
                string privateKey = "12b9a8eb3eec3714d5e658b378ff1ad30ec7ab32";
                string baseUrl = "http://gateway.marvel.com/v1/public/";
                string hash = GerarHash(ts, publicKey, privateKey);

                HttpResponseMessage response = client.GetAsync(baseUrl +
                    $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"name={Uri.EscapeUriString(textoPesquisa)}").Result;

                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultado = JsonConvert.DeserializeObject(conteudo);
                var obteveRetorno = false;
                personagem = new PersonagemDTO();
                if (resultado.data.count > 0)
                {
                    personagem.Id = resultado.data?.results[0].id;
                    personagem.Nome = resultado.data?.results[0].name;
                    personagem.Descricao = resultado.data.results[0].description;
                    personagem.UrlImagem = resultado.data.results[0].thumbnail.path + "." +
                                           resultado.data.results[0].thumbnail.extension;
                    foreach(var historia in resultado.data.results[0].stories)
                    {
                        personagem.Historias.Add(historia.name);
                    }
                    obteveRetorno = true;
                    PesquisaBusiness.InserePesquisa(textoPesquisa, obteveRetorno);
                }
                else
                {
                    PesquisaBusiness.InserePesquisa(textoPesquisa, obteveRetorno);
                }

            }

            return View (personagem);
        }
    }
}