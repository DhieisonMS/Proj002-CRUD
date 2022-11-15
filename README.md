# Proj002-CRUD

- deletar arquivos desnecessário
    - Controllers
    - obj


# instalar packote EntityFrameworkCore

 - dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.2
 - dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.2
 - dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.2

# configurar ContextDB

    public class ConnectDB : DbContext
    {
        public ConnectDB(DbContextOptions<ConnectDB> options) : base(options)
        {

        }
        public DbSet<User> Users{get; set;}
    }
# configurar Conexão com o Banco
    - 1: configurar String de conexão no appsetthings.json
    "ConnectionStrings": {
    "Default":"Server=172.20.0.3; Database=crud01; Uid=root; Pwd=12345a "
  }

# configure a inicialização do banco no arquivo Program.cs
    -
        using Microsoft.EntityFrameworkCore;
        using Microsoft.Extensions.Configuration;

        using src.Context;

        var Connection = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<ConnectDB>(options => options.UseMySql(Connection, ServerVersion.AutoDetect(Connection)));

# habilitar o tls
    - dotnet dev-certs https --trust

# primeiro migration

dotnet-ef migrations add primeira tabela

dotnet-ef database update


