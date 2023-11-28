using AutoMapper;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.AutoMapper
{
    public class DomainToApplication : Profile
    {
        public DomainToApplication() 
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
        }
    }
}
