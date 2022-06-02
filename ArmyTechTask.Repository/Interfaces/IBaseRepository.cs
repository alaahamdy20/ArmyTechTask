namespace ArmyTechTask.repository.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}