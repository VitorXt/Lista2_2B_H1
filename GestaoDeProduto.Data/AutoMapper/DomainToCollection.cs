using AutoMapper;
using GestaoDeProduto.Data.Providers.MongoDb.Collections;
using GestaoDeProdutos.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.AutoMapper
{
	public class DomainToCollection : Profile
	{
		public DomainToCollection()
		{
			CreateMap<Produto, ProdutoCollection>();
			CreateMap<Categoria, CategoriaCollection>();
			CreateMap<Fornecedor, FornecedorCollection>();
		}
	}
}