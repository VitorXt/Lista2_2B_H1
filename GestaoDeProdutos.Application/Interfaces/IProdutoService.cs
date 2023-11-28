using GestaoDeProdutos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoViewModel> ObterTodos();
        IEnumerable<ProdutoViewModel> ObterPorNome(string nome);
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);
        Task Adicionar(NovoProdutoViewModel produto);
        Task Atualizar(Guid id, AtualizarProdutoViewModel produto);
        Task AlterarPreco(Guid id, decimal valor);
        Task AtualizarEstoque(Guid id, int quantidade);
        Task Desativar(Guid id);
        Task Reativar(Guid id);
    }
}
