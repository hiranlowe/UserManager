using UserManager.Data.Models;

namespace UserManager.Data.Services;
public class UserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task AddUserAsync(int id, string name)
    {
        var user = new User { Id = id, Name = name };
        await this._unitOfWork.Users.AddAsync(user);
        await this._unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await this._unitOfWork.Users.GetAllAsync();
    }
}



