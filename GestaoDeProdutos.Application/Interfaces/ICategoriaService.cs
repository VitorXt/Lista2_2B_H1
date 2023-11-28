using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaViewModel> ObterTodas();
        Task<CategoriaViewModel> ObterPorId(Guid id);

        Task Adicionar(NovaCategoriaViewModel categoriaViewModel);
        void Atualizar(NovaCategoriaViewModel categoriaViewModel);
    }
}
