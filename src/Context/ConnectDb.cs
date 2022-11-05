using Microsoft.EntityFramework;
using src.Entities;
namespace src.Context;

public class ConnectDb:DbContext
{
    public ConnectDb(DbContextOpitions<ConnectDb> options) : base(options)
    {

    }

    public Dbset<User> Users { get; set}
}