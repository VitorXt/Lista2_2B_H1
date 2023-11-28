using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        //o que fazer
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPorNome(string nome);
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        Task AlterarPreco(Produto produto);
        Task AtualizarEstoque(Produto produto);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Desativar(Produto produto);
        Task Reativar(Produto produto);
    }
}
