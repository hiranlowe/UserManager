namespace UserManager.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly List<T> _dbSet;

    public Repository(List<T> dbSet)
    {
        this._dbSet = dbSet;
    }

    public Task<T?> GetByIdAsync(int id)
    {
        var entity = this._dbSet.FirstOrDefault(x => (x as dynamic).Id == id); // Use dynamic to access the 'Id' property
        return Task.FromResult(entity);
    }
    public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult(this._dbSet.AsEnumerable());

    public Task AddAsync(T entity)
    {
        this._dbSet.Add(entity);
        return Task.CompletedTask;
    }

    public void Update(T entity) { /* In-memory update logic if needed */ }

    public void Delete(T entity) => this._dbSet.Remove(entity);
}
