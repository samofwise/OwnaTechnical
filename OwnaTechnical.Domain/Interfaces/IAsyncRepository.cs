using OwnaTechnical.Domain.Base;

namespace OwnaTechnical.Domain.Interfaces
{
	public interface IAsyncRepository<T> where T : BaseEntity
	{
		Task<T?> GetAsync(Func<T, bool> expression);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<bool> DeleteAsync(T entity);
	}
}
