using UserManager.Data;
using UserManager.Data.Services;

var serviceProvider = new ServiceCollection()
           .AddScoped<IUnitOfWork, UnitOfWork>()             // Register UnitOfWork as Scoped
           .AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>() // Register Factory for UnitOfWork
           .AddScoped<UserService>()                          // Register UserService
           .BuildServiceProvider();

var factory = new UnitOfWorkFactory();
var userService = new UserService(factory);

userService.RegisterUserWithOrder();

using var unitOfWork = factory.Create();
var users = unitOfWork.Users.GetAll();
var orders = unitOfWork.Orders.GetAll();

Console.WriteLine("Users:");
foreach (var user in users)
{
    Console.WriteLine($"- {user.Id}: {user.Name} ({user.Email})");
}

Console.WriteLine("Orders:");
foreach (var order in orders)
{
    Console.WriteLine($"- Order {order.Id}: User {order.UserId}, Total: {order.TotalAmount}");
}