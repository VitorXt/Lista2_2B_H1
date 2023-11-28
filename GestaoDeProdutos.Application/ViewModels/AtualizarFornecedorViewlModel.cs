using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class AtualizarFornecedorViewlModel
    {
        #region - Propriedades

        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }

        #endregion
    }
}
