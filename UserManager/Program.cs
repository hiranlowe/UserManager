using Microsoft.Extensions.DependencyInjection;
using UserManager;
using UserManager.Data;
using UserManager.Data.Services;



// Configure DI
var services = new ServiceCollection();

// Register dependencies
services.AddSingleton<InMemoryDatabase>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
services.AddScoped<UserService>();
services.AddScoped<OrderService>();

var serviceProvider = services.BuildServiceProvider();

// Get services
var userService = serviceProvider.GetRequiredService<UserService>();
var orderService = serviceProvider.GetRequiredService<OrderService>();

// Add Users
await userService.AddUserAsync(1, "Alice");
await userService.AddUserAsync(2, "Bob");
await userService.AddUserAsync(3, "Charlie");

// Add Orders
await orderService.AddOrderAsync(1, 1, "Laptop", 1200.99m);
await orderService.AddOrderAsync(2, 1, "Mouse", 25.50m);
await orderService.AddOrderAsync(3, 2, "Keyboard", 45.99m);
await orderService.AddOrderAsync(4, 3, "Monitor", 250.00m);

// Print All Users and Orders
Console.WriteLine("\n=== Users and Their Orders ===");
var users = await userService.GetAllUsersAsync();
foreach (var user in users)
{
    Console.WriteLine($"User: {user.Name}");
    foreach (var order in user.Orders)
    {
        Console.WriteLine($"  - Order: {order.Product} (${order.Price})");
    }
}

Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();  // Waits for the user to press Enter