namespace AbraAssignment.Server.Repositories
{
	public interface IRepository<T>
	{
		Task<List<T>> GetAllAsync();
		Task<T> CreateAsync(T entity);
	}
}
