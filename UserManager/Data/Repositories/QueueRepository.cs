namespace UserManager.Data.Repositories;
public class QueueRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _queue = new();
    private int _nextId = 1;

    public T GetById(int id)
    {
        return this._queue.FirstOrDefault(e => (int)e.GetType().GetProperty("Id")?.GetValue(e) == id);
    }

    public IEnumerable<T> GetAll()
    {
        return this._queue.ToList();
    }

    public void Add(T entity)
    {
        entity.GetType().GetProperty("Id")?.SetValue(entity, this._nextId++);
        this._queue.Add(entity);
    }

    public void Update(T entity)
    {
        var existing = this.GetById((int)entity.GetType().GetProperty("Id")?.GetValue(entity));
        if (existing != null)
        {
            this._queue.Remove(existing);
            this._queue.Add(entity);
        }
    }

    public void Delete(int id)
    {
        var entity = this.GetById(id);
        if (entity != null)
        {
            this._queue.Remove(entity);
        }
    }
}