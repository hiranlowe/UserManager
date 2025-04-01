namespace UserManager.Data;
public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    public IUnitOfWork Create()
    {
        return new UnitOfWork();
    }
}
