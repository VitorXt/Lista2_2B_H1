using AutoMapper;
using GestaoDeProduto.Data.Providers.MongoDb.Collections;
using GestaoDeProduto.Data.Providers.MongoDb.Interfaces;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        #region - Atributos e Construtor

        private readonly IMongoRepository<FornecedorCollection> _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorRepository(IMongoRepository<FornecedorCollection> fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Métodos

        public async Task Adicionar(Fornecedor fornecedor)
        {
            var novoFornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);
            await _fornecedorRepository.InsertOneAsync(novoFornecedorCollection);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            var buscaFornecedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);

            if (buscaFornecedor == null) throw new ApplicationException("Não é possível alterar um fornecedor que não existe");

            var fornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornecedorCollection.Id = buscaFornecedor.FirstOrDefault().Id;

            await _fornecedorRepository.ReplaceOneAsync(_mapper.Map<FornecedorCollection>(fornecedor));
        }

        public async Task Remover(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public async Task<Fornecedor> ObterPorCnpj(string cnpj)
        {
            var fornecedorEncontradoPorCnpj = await _fornecedorRepository.FindOneAsync(filtro => filtro.Cnpj == cnpj);
            return _mapper.Map<Fornecedor>(fornecedorEncontradoPorCnpj);
        }

        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            var fornecedorEncontradoPorId = await _fornecedorRepository.FindOneAsync(filtro => filtro.CodigoId == id);
            return _mapper.Map<Fornecedor>(fornecedorEncontradoPorId);
        }

        public async Task<Fornecedor> ObterPorNome(string nome)
        {
            FornecedorCollection fornecedorEncontradoPorNome = await _fornecedorRepository.FindOneAsync(filtro => filtro.Nome == nome);
            return _mapper.Map<Fornecedor>(fornecedorEncontradoPorNome);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            IEnumerable<FornecedorCollection>listaDeFornecedores = _fornecedorRepository.FilterBy(filtro => true);

            return _mapper.Map<IEnumerable<Fornecedor>>(listaDeFornecedores);

        }

        public async Task Reativar(Fornecedor fornecedor)
        {
            var buscaFornencedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);

            if (buscaFornencedor == null) throw new ApplicationException("Não é possível reativar um fornecedor que não existe");

            var fornencedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornencedorCollection.Id = buscaFornencedor.FirstOrDefault().Id;

            await _fornecedorRepository.ReplaceOneAsync(fornencedorCollection);
        }

        public async Task Desativar(Fornecedor fornecedor)
        {
            var buscaFornencedor = _fornecedorRepository.FilterBy(filter => filter.CodigoId == fornecedor.CodigoId);

            if (buscaFornencedor == null) throw new ApplicationException("Não é possível reativar um fornecedor que não existe");

            var fornencedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);

            fornencedorCollection.Id = buscaFornencedor.FirstOrDefault().Id;

            await _fornecedorRepository.ReplaceOneAsync(fornencedorCollection);
        }

        #endregion
    }
}
