using Microsoft.Extensions.Caching.Memory;
using OwnaTechnical.Domain.Base;
using OwnaTechnical.Domain.Interfaces;

namespace OwnaTechnical.Infrastructure.Data.Repositories
{
	public abstract class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity<int>
	{
		private readonly IMemoryCache _memoryCache;
		private readonly string key = typeof(T).Name;

		public RepositoryBase(IMemoryCache memoryCache)
			=> _memoryCache = memoryCache;

		public Task<T?> GetAsync(Func<T, bool> expression)
		{
			return Task.FromResult(_memoryCache.Get<List<T>>(key)?.SingleOrDefault(expression));
		}

		public Task<T> AddAsync(T entity)
		{
			var newEntity = entity;

			if (!_memoryCache.TryGetValue(key, out List<T>? cacheList))
			{
				newEntity.Id = cacheList?.Count + 1 ?? 1;

				var list = cacheList != null ? cacheList.Append(newEntity).ToList() : new List<T>() { newEntity };

				if (cacheList == null)
					_memoryCache.CreateEntry(key);

				_memoryCache.Set(key, list);
			}

			return Task.FromResult(newEntity);
		}

		public Task<T> UpdateAsync(T entity)
		{
			if (!_memoryCache.TryGetValue(key, out List<T>? cacheList))
			{
				if (cacheList == null)
					throw new ArgumentNullException(nameof(cacheList));

				var existingEntity = cacheList.SingleOrDefault(i => i.Id == entity.Id);

				if (existingEntity == null)
					throw new KeyNotFoundException($"Memory Collection of {key} does not contain item with id {entity.Id}");

				cacheList = cacheList.Where(i => i.Id != entity.Id).Append(entity).ToList();

				_memoryCache.Set(key, cacheList);
			}

			return Task.FromResult(entity);
		}

		public Task<bool> DeleteAsync(T entity)
		{
			return Task.FromResult(false);
		}
	}
}
