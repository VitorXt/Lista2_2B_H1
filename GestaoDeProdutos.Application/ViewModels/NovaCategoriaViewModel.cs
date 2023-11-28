using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class NovaCategoriaViewModel
    {
        #region Propriedades

        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        #endregion
    }
}
