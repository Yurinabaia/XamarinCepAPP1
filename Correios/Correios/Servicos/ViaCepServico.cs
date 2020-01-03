using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Correios.Servicos.Modelo;
using Newtonsoft.Json;

namespace Correios.Servicos
{
   public class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCep (string cep) 
        {
            string NovoEndereco = string.Format(EnderecoUrl, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEndereco);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if (end.cep == null) return null;
            return end;
        }
    }
}
