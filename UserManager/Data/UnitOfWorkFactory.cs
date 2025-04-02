using Microsoft.Extensions.DependencyInjection;

namespace UserManager.Data;
public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public IUnitOfWork Create()
    {
        return this._serviceProvider.GetRequiredService<IUnitOfWork>();
    }
}

