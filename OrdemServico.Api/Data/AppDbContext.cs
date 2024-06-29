using Microsoft.EntityFrameworkCore;
using OrdemServico.Api.Entities;

namespace OrdemServico.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Situacao> Status { get; set; }

        public DbSet<ServicoOrdem> ServicoOrdem { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<TipoOrdem> TipoOrdem { get; set; }
        public DbSet<TipoPessoa> TipoPessoa { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Situacao> Situacao { get; set; }


        public DbSet<Ordem> Ordem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => new { p.Id, p.CpfCnpj });

            //-- CRIAR PELO MENOS UM REGISTRO EM CADA TABELA PADRÃO
            modelBuilder.Entity<TipoProduto>().HasData(new List<TipoProduto>
            {
                new() { Id = 1, Codigo = 1, Nome = "Próprio" },
                new() { Id = 2, Codigo = 2, Nome = "Terceiro" },
                new() { Id = 3, Codigo = 3, Nome = "Mão de obra" }
            });

            modelBuilder.Entity<TipoPessoa>().HasData(new List<TipoPessoa>
            {
                new() { Id = 1, Codigo = 1, Nome = "Física" },
                new() { Id = 2, Codigo = 2, Nome = "Jurídica" },
                new() { Id = 3, Codigo = 3, Nome = "Outro" }
            });

            modelBuilder.Entity<TipoOrdem>().HasData(new List<TipoOrdem>
            {
                new() { Id = 1, Codigo = 1, Nome = "Manutenção" },
                new() { Id = 2, Codigo = 2, Nome = "Compra" },
                new() { Id = 3, Codigo = 3, Nome = "Venda" }
            });            
            
            modelBuilder.Entity<Situacao>().HasData(new List<Situacao>
            {
                new() { Id = 1, Codigo = 1, Nome = "Cadastrado" },
                new() { Id = 2, Codigo = 2, Nome = "Ag modificação" },
                new() { Id = 3, Codigo = 3, Nome = "Ag aprovação" },
                new() { Id = 4, Codigo = 4, Nome = "Ativo" },
                new() { Id = 5, Codigo = 5, Nome = "Cancelado" },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
