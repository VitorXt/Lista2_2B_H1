using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task Adicionar(NovoFornecedorViewModel novoFornecedorViewModel);
        Task Atualizar(Guid id, AtualizarFornecedorViewlModel fornecedor);
        Task Remover(FornecedorViewModel fornecedor);
        Task<FornecedorViewModel> ObterPorId(Guid id);
        Task<FornecedorViewModel> ObterPorNome(string nome);
        Task<FornecedorViewModel> ObterPorCnpj(string cnpj);
        Task<IEnumerable<FornecedorViewModel>> ObterTodos();
        Task Desativar(Guid id);
        Task Reativar(Guid id);
    }
}
