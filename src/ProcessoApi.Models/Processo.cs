using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoApi.Models
{
    public class Processo
    {
        [JsonProperty("Processo")]
        public List<DadosProcesso> Dados { get; set; }
    }
}
