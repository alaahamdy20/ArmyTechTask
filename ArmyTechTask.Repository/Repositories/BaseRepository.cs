

using ArmyTechTask.repository.Data;
using ArmyTechTask.repository.Interfaces;


namespace ArmyTechTask.repository.Repositories{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly ArmyTechTaskContext _context;


        public BaseRepository(ArmyTechTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>();
        }
    }
}
