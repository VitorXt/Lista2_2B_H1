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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoRepository<ProdutoCollection> _produtoRepository;
        private readonly IMapper _mapper;

        #region - Construtores

        public ProdutoRepository(IMongoRepository<ProdutoCollection> produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Funções

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.InsertOneAsync(_mapper.Map<ProdutoCollection>(produto));
        }

        public async Task Atualizar(Produto produto)
        {
            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == produto.CodigoId);

            if (buscaProduto == null) throw new ApplicationException("Não é possível alterar um produto que não existe");

            var produtoCollection = _mapper.Map<ProdutoCollection>(produto);

            produtoCollection.Id = buscaProduto.FirstOrDefault().Id;

            await _produtoRepository.ReplaceOneAsync(_mapper.Map<ProdutoCollection>(produto));
        }

        public async Task AlterarPreco(Produto produto)
        {

            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == produto.CodigoId);

            if (buscaProduto == null) throw new ApplicationException("Não é possível alterar o preço de um produto que não existe");

            var produtoCollection = _mapper.Map<ProdutoCollection>(produto);

            produtoCollection.Id = buscaProduto.FirstOrDefault().Id;

            await _produtoRepository.ReplaceOneAsync(produtoCollection);
        }

        public async Task AtualizarEstoque(Produto produto)
        {
            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == produto.CodigoId);

            if (buscaProduto == null) throw new ApplicationException("Não é possível alterar o estoque de um produto que não existe");

            var produtoCollection = _mapper.Map<ProdutoCollection>(produto);

            produtoCollection.Id = buscaProduto.FirstOrDefault().Id;

            await _produtoRepository.ReplaceOneAsync(produtoCollection);
        }

        public async Task Desativar(Produto produto)
        {

            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == produto.CodigoId);

            if (buscaProduto == null) throw new ApplicationException("Não é possível desativar um produto que não existe");

            var produtoCollection = _mapper.Map<ProdutoCollection>(produto);

            produtoCollection.Id = buscaProduto.FirstOrDefault().Id;

            await _produtoRepository.ReplaceOneAsync(produtoCollection);
        }

        public async Task Reativar(Produto produto)
        {

            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == produto.CodigoId);

            if (buscaProduto == null) throw new ApplicationException("Não é possível reativar um produto que não existe");

            var produtoCollection = _mapper.Map<ProdutoCollection>(produto);

            produtoCollection.Id = buscaProduto.FirstOrDefault().Id;

            await _produtoRepository.ReplaceOneAsync(produtoCollection);
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterPorNome(string nome)
        {
            var buscaProduto = _produtoRepository.FilterBy(filter => filter.Nome == nome);

            var produto = _mapper.Map<IEnumerable<Produto>>(buscaProduto.All(filter => filter.Nome == nome));

            return _mapper.Map<IEnumerable<Produto>>(produto);
        }

        public Task<Produto> ObterPorId(Guid id)
        {
            var buscaProduto = _produtoRepository.FilterBy(filter => filter.CodigoId == id);

            var produto = _mapper.Map<Task<Produto>>(buscaProduto.FirstOrDefault());

            return produto;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            var produtoList = _produtoRepository.FilterBy(filter => true);

            return _mapper.Map<IEnumerable<Produto>>(produtoList);

        }

        #endregion
    }
}
