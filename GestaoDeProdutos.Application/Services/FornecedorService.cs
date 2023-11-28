using AutoMapper;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        #region - Construtores

        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Funções

        public async Task Adicionar(NovoFornecedorViewModel novoFornecedorViewModel)
        {
            var novoFornecedor = _mapper.Map<Fornecedor>(novoFornecedorViewModel);
            await _fornecedorRepository.Adicionar(novoFornecedor);
        }

        public Task Remover(FornecedorViewModel fornecedor)
        {
            throw new NotImplementedException();
        }

        public async Task Atualizar(Guid id, AtualizarFornecedorViewlModel fornecedor)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível atualizar um fornecedor que não existe!");

            var fornecedorAlterado = _mapper.Map<Fornecedor>(fornecedor);

            buscaFornecedor.Alterar(fornecedorAlterado);

            await _fornecedorRepository.Atualizar(buscaFornecedor);
        }

        public async Task Desativar(Guid id)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível desativar um fornecedor que não existe!");

            buscaFornecedor.Desativar();

            await _fornecedorRepository.Desativar(buscaFornecedor);
        }

        public async Task Reativar(Guid id)
        {
            var buscaFornecedor = await _fornecedorRepository.ObterPorId(id);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível reativar um fornecedor que não existe!");

            buscaFornecedor.Ativar();

            await _fornecedorRepository.Reativar(buscaFornecedor);
        }

        public async Task<FornecedorViewModel> ObterPorCnpj(string cnpj)
        {
            return _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterPorCnpj(cnpj));
        }

        public async Task<FornecedorViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterPorId(id));
        }

        public async Task<FornecedorViewModel> ObterPorNome(string nome)
        {
            return _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterPorNome(nome));
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            return _mapper.Map<List<FornecedorViewModel>>(_fornecedorRepository.ObterTodos());
        }   

        #endregion
    }
}
