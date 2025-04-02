using UserManager.Data.Models;
using UserManager.Data.Repositories;

namespace UserManager.Data;
public interface IUnitOfWork
{
    IRepository<User> Users { get; }
    IRepository<Order> Orders { get; }
    Task SaveAsync();
}
