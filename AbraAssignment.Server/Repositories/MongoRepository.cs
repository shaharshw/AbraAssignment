using MongoDB.Driver;

namespace AbraAssignment.Server.Repositories
{ 
	public class MongoRepository<T> : IRepository<T> where T : class
	{
		private readonly IMongoCollection<T> m_collection;

		public MongoRepository(IMongoClient client, string databaseName, string collectionName)
		{
			var database = client.GetDatabase(databaseName);
			m_collection = database.GetCollection<T>(collectionName);
		}

		public async Task<List<T>> GetAllAsync()
		{
			var list = new List<T>();
			try
			{
				list = await m_collection.AsQueryable().ToListAsync();
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.ToString());
			}

			return list;
		}

		public async Task<T> CreateAsync(T entity)
		{
			try
			{
				await m_collection.InsertOneAsync(entity);
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.ToString());
			}

			return entity;
		}
	}
}
