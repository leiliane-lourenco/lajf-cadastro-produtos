using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Lajf.Cadastro.Produtos.API.ViewModel
{
    public class ProdutoViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("fornecedor_id")]
        public Guid FornecedorId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("data_cadastro")]
        public DateTime DataCasdastro { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
