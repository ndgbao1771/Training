namespace Training.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();

        T FindById(int Id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Commit();
    }
}