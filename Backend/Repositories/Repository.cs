using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories{ 
public class Repository<T> : Interface.IRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
            this.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
            this.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        this.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
  }

}
