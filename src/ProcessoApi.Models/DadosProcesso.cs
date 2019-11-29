using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcessoApi.Models
{
    [Table("processos_monstrao")]
    public class DadosProcesso
    {
        [Key]
        [Column("id_processo")]
        [JsonProperty("n")]
        public string CodigoProcesso { get; set; }

        //[Column("")]
        //[JsonProperty("cpf_cnpj_autor")]
        //public string CpfCnpjAutor { get; set; }

        //[Column("")]
        //[JsonProperty("cpf_cnpj_reu")]
        //public string CpfCnpjReu { get; set; }

        [Column("data_tramitacao")]
        [JsonProperty("Data_tramitacao")]
        public string DataTramitacao { get; set; }

        [Column("natureza")]
        [JsonProperty("Natureza")]
        public string Natureza { get; set; }

        [Column("area_direito")]
        [JsonProperty("Area_direito")]
        public string AreaDireito { get; set; }

        [Column("assunto")]
        [JsonProperty("Assunto")]
        public string Assunto { get; set; }
    }
}
