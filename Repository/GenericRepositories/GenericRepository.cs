using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression == null) throw new NullReferenceException("Please enter a field to search for.");

            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Create(T entity)
        {
            if (entity is null) throw new NullReferenceException("Entity is null.");

            _db.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new Exception("Invalid id.");

            var entity = await _db.FindAsync(id);

            if (entity is null) throw new KeyNotFoundException("No entity with the current id.");

            _db.Remove(entity);

        }

        public void Update(T entity)
        {
            if (entity is null) throw new NullReferenceException("Entity is null.");

            _db.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
