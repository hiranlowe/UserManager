using UserManager.Data.Models;
using UserManager.Data.Repositories;

namespace UserManager.Data;
public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Order> Orders { get; }
    void Commit();
}
