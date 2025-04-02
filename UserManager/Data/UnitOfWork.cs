using UserManager.Data.Models;
using UserManager.Data.Repositories;

namespace UserManager.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly InMemoryDatabase _database;

    public IRepository<User> Users { get; }
    public IRepository<Order> Orders { get; }

    public UnitOfWork(InMemoryDatabase database)
    {
        this._database = database;
        this.Users = new Repository<User>(this._database.Users);
        this.Orders = new Repository<Order>(this._database.Orders);
    }

    public Task SaveAsync() => Task.CompletedTask; // No actual save needed for in-memory lists
}
