using Microsoft.EntityFrameworkCore;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });
            base.OnModelCreating(modelBuilder);

            modelBuilder
            .Entity<Endereco>()
            .ToTable("Enderecos");

            modelBuilder  //criando chave primária para a tabela Endereco - shadow properties (escondida)
            .Entity<Endereco>()
            .Property<int>("ClienteId");

            modelBuilder
            .Entity<Endereco>()
            .HasKey("ClienteId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP-NKSGK1T\\SQLEXPRESS; Initial Catalog = LojaDB; Integrated Security=True");
                
            }
        }
    }
}