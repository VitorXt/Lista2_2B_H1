﻿using AutoMapper;
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
    public class CategoriaService : ICategoriaService
    {
        #region - Construtores

        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Funções

        public async Task Adicionar(NovaCategoriaViewModel categoriaViewModel)
        {
            var novaCategoria = _mapper.Map<Categoria>(categoriaViewModel);

            Categoria categoria = new Categoria(categoriaViewModel.Descricao, categoriaViewModel.Ativo);

            await _categoriaRepository.Adicionar(categoria);
        }

        public void Atualizar(NovaCategoriaViewModel categoriaViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaRepository.ObterTodas());

        }

        #endregion
    }
}
