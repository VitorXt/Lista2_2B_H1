using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        public Task Adicionar(Fornecedor fornecedor);
        public Task Atualizar(Fornecedor fornecedor);
        public Task Remover(Fornecedor fornecedor);
        public Task<Fornecedor> ObterPorId(Guid id);
        public Task<Fornecedor> ObterPorNome(string nome);
        public Task<Fornecedor> ObterPorCnpj(string cnpj);
        public Task<IEnumerable<Fornecedor>> ObterTodos();
        Task Desativar(Fornecedor fornecedor);
        Task Reativar(Fornecedor fornecedor);
    }
}
