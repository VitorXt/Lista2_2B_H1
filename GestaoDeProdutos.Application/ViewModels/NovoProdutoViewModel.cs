using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class NovoProdutoViewModel
    {
        #region - Propriedades

        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "É necessário informar um valor")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor tem que ser maior que 0")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }

        [JsonIgnore]
        public int EstoqueMinimo { get; set; }


        #endregion
    }
}
