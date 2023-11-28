using AutoMapper;
using GestaoDeProduto.Data.Providers.MongoDb.Collections;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.AutoMapper
{
	public class CollectionToDomain : Profile
	{
		public CollectionToDomain()
		{

			CreateMap<ProdutoCollection, Produto>()
			   .ConstructUsing(q => new Produto(q.CodigoId, q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque, q.EstoqueMinimo));

			CreateMap<CategoriaCollection, Categoria>()
			   .ConstructUsing(q => new Categoria(q.CodigoId,  q.Descricao, q.Ativo));

			CreateMap<FornecedorCollection, Fornecedor>()
					.ConstructUsing(f => new Fornecedor(f.CodigoId, f.Nome, f.RazaoSocial, f.Cnpj, f.DataCadastro, f.Ativo));
		}
	}
}
