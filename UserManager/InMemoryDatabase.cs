using UserManager.Data.Models;

namespace UserManager;
public class InMemoryDatabase
{
    public List<User> Users { get; } = new();
    public List<Order> Orders { get; } = new();
}

