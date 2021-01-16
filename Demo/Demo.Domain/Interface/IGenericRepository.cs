namespace Demo.Domain.Interface
{
    public interface IGenericRepository<T>
    {
        T Get(int id);

        bool Create(T entity);

        bool Update(int id, T entity);

        bool Delete(int id);
    }
}