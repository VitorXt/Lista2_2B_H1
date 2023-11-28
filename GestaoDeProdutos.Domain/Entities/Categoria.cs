using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Categoria : EntidadeBase
    {
        #region 1 - Construtor

        public Categoria(string descricao, bool ativo)
        {
            Descricao = descricao;
            Ativo = ativo;
        }

        public Categoria(Guid codigoId, string descricao, bool ativo)
        {
            CodigoId = codigoId;
            Descricao = descricao;
            Ativo = ativo;
        }

        #endregion

        #region 2 - Propriedades

        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        #endregion

        #region 3 - Comportamentos

        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        #endregion
    }
}
