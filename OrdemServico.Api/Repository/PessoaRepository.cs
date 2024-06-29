﻿using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;
using OrdemServico.Api.Interface;
using OrdemServico.Data;
using OrdemServico.Models.DTO;

namespace OrdemServico.Api.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoa(int? codigo = null, string? cpfCnpj = null, string? nome = null, string? tipo = null, int? situacao = null)
        {
            var query = _context.Pessoa
                                .Include(c => c.Tipo)
                                .Include(c => c.Situacao)
                                .AsQueryable();

            // Aqui pra baixo vai tentar filtra conforme os parâmetros passados
            if (codigo.HasValue)
            {
                query = query.Where(p => p.Codigo == codigo);
            }

            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                query = query.Where(p => p.CpfCnpj == cpfCnpj);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.Nome != null ? p.Nome.Contains(nome) : false);
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                query = query.Where(p => p.Tipo.Nome == tipo);
            }

            if (situacao.HasValue)
            {
                query = query.Where(p => p.Situacao.Id == situacao);
            }

            return await query.ToListAsync();
        }

        public async Task<Pessoa> CadastrarPessoa(PessoaPostDTO pessoa)
        {
            // Busca o Tipo pelo nome
            var tipoPessoa = await _context.TipoPessoa.FirstOrDefaultAsync(t => t.Nome == pessoa.TipoNome);

            if (tipoPessoa == null)
            {
                throw new ArgumentException("Tipo de Pessoa não encontrado.");
            }

            // Busca a situação default (Cadastrada)
            var situacao = await _context.Situacao.FirstOrDefaultAsync(t => t.Id == 1);
            if (situacao == null)
            {
                throw new ArgumentException("Situação padrão para cadastro de registro não foi encontrada.");
            }

            // Gera um código novo com base no último cadastrado no banco
            var ultimoCodigo = await _context.Pessoa.MaxAsync(p => (int?)p.Codigo) ?? 0;
            var novoCodigo = ultimoCodigo + 1;

            // Cria a nova instância de Pessoa
            var novaPessoa = new Pessoa
            {
                Codigo = novoCodigo,
                Nome = pessoa.Nome,
                CpfCnpj = pessoa.CpfCnpj,
                Contato = pessoa.Contato,
                Tipo = tipoPessoa,
                Situacao = situacao
            };

            // Adiciona a nova Pessoa ao contexto e salva as alterações
            _context.Pessoa.Add(novaPessoa);
            await _context.SaveChangesAsync();

            return novaPessoa;
        }
    }
}