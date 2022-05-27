using Alura.ByteBank.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Alura.ByteBank.Dados.Contexto
{
  /// <summary>
  /// Principais configurações para azure devOps
  /// </summary>
  public class ByteBankContexto : DbContext
  {
    public DbSet<ContaCorrente> ContaCorrentes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Agencia> Agencias { get; set; }
    public DbSet<UsuarioApp> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //string connection get in Portal azure mysql for windos.
      /* 1 - string connection get in Portal azure mysql for windos.
       * 2 - Enter Update-Database in console.
       * 3 - Available in Azure.
       * 
       * MySqlConnector.MySqlException (0x80004005): Client with IP address '170.78.33.121' is not allowed to connect to this MySQL server.
       * ---> Problema: depois de um tempo parou de funcionar o mysql azure, estava relacionado com o IP an seção de segurança
       * ---> Eu apaguei o banco, criei um outro, configurei tudo no azure e rodei o updataDatabase
       */

      string stringconexao = "Server=databasetreinamento.mysql.database.azure.com; " +
                              "Port=3306; Database=databasetreinamento; " +
                              "Uid=kilua@databasetreinamento; Pwd=W%N6*bJM3n;";

      optionsBuilder.UseMySql(stringconexao,
                              ServerVersion.AutoDetect(stringconexao));



    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<Cliente>(entity =>
      {
        entity.ToTable("cliente");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Nome).IsRequired();
        entity.Property(e => e.Identificador);
        entity.Property(e => e.Profissao).IsRequired();
        entity.Property(e => e.CPF).IsRequired();
      });

      modelBuilder.Entity<Agencia>(entity =>
      {
        entity.ToTable("agencia");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Numero).IsRequired();
        entity.Property(e => e.Endereco);
        entity.Property(e => e.Identificador);
        entity.Property(e => e.Nome).IsRequired();

      });

      modelBuilder.Entity<ContaCorrente>(entity =>
      {
        entity.ToTable("conta_corrente");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Numero).IsRequired();
        entity.Property(e => e.Identificador);
        entity.Property(e => e.PixConta);
        entity.Property(e => e.Saldo);
        entity.HasOne(d => d.Cliente).WithMany(p => p.Contas);
        entity.HasOne(d => d.Agencia).WithMany(p => p.Contas);
      });

      modelBuilder.Entity<UsuarioApp>(entity =>
      {
        entity.ToTable("usuario");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.UserName).IsRequired();
        entity.Property(e => e.Email).IsRequired();
        entity.Property(e => e.Senha).IsRequired();
      });

      base.OnModelCreating(modelBuilder);
    }

  }
}
