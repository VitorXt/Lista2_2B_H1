using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class CategoriaViewModel
    {
        #region - Propriedades

        public Guid CodigoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        #endregion
    }
}
