using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lajf.Cadastro.Produtos.API.ViewModel
{
    public class FornecedorViewModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }


        [JsonProperty("documento")]
        public string Documento { get; set; }


        [JsonProperty("tipo_fornecedor")]
        public int TipoFornecedor { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
