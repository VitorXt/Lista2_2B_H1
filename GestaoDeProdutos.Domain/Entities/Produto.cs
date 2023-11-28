﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        #region 1 - Contrutores

        public Produto(string nome, string descricao, decimal valor, string imagem, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public Produto(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, int quantidadeEstoque, int estoqueMinimo)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            EstoqueMinimo = estoqueMinimo;
        }

        public Produto(Guid codigoId, string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, int quantidadeEstoque, int estoqueMinimo)
        {
            CodigoId = codigoId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            EstoqueMinimo = estoqueMinimo;
        }

        #endregion

        #region 2 - Propriedades

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Guid CategoriaID { get; private set; }
        public int EstoqueMinimo { get; private set; }

        #endregion

        #region 3 - Comportamentos

        public void Reativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void AlterarPreco(Decimal valor) => Valor = valor;
        public void AlterarProduto(Produto produto)
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Valor = produto.Valor;
            Imagem = produto.Imagem;
            QuantidadeEstoque = produto.QuantidadeEstoque;
        }
        public void AlterarCategoria(Guid categoriaID) => CategoriaID = categoriaID;
        public void DebitarEstoque(int quantidade)
        {
            if (!PossuiEstoque(quantidade)) throw new Exception("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }
        public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;
        public bool VeririficaEstoqueMinimo() => QuantidadeEstoque < EstoqueMinimo;

        #endregion
    }
}
