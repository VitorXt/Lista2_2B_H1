using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class NovoFornecedorViewModel
    {
        #region - Propriedades

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public bool Ativo { get; set; }

        #endregion
    }
}
