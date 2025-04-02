using UserManager.Data.Models;

namespace UserManager.Data.Services;
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task AddOrderAsync(int orderId, int userId, string product, decimal price)
    {
        var order = new Order { Id = orderId, UserId = userId, Product = product, Price = price };
        await this._unitOfWork.Orders.AddAsync(order);

        var user = await this._unitOfWork.Users.GetByIdAsync(userId);
        if (user != null)
        {
            user.Orders.Add(order);
        }

        await this._unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await this._unitOfWork.Orders.GetAllAsync();
    }
}

