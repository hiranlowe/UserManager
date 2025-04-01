using UserManager.Data.Models;
using UserManager.Data.Repositories;

namespace UserManager.Data;
public class UnitOfWork : IUnitOfWork
{
    public IRepository<User> Users { get; }
    public IRepository<Order> Orders { get; }

    public UnitOfWork()
    {
        this.Users = new QueueRepository<User>();
        this.Orders = new QueueRepository<Order>();
    }

    public void Commit()
    {
        Console.WriteLine("All operations committed.");
    }
}