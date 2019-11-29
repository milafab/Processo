using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoApi.Models
{
    public class Envelpe
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        public Envelpe(object value)
        {
            Data = value;
        }
    }
}
