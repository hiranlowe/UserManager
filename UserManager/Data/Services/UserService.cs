using UserManager.Data.Models;

namespace UserManager.Data.Services;
public class UserService
{
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public UserService(IUnitOfWorkFactory unitOfWorkFactory)
    {
        this._unitOfWorkFactory = unitOfWorkFactory;
    }

    public void RegisterUserWithOrder()
    {
        using var unitOfWork = this._unitOfWorkFactory.Create();

        var user = new User { Name = "Alice", Email = "alice@example.com" };
        unitOfWork.Users.Add(user);

        var order = new Order { UserId = user.Id, TotalAmount = 99.99m };
        unitOfWork.Orders.Add(order);

        unitOfWork.Commit();
    }
}
