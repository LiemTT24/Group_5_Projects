namespace Group5_API_Project.Services.CommonServices
{
    public interface ICommonServices<TEntity> where TEntity : class
    {
        Task<bool> AnyAsync(int id);
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
