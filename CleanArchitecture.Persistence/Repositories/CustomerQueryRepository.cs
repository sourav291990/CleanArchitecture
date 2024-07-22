namespace CleanArchitecture.Persistence.Repositories
{
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;
    using CleanArchitecture.Persistence.DbContexts;
    using CleanArchitecture.Domain.Entities.Customer;
    using CleanArchitecture.Application.Models.CustomerQuery;
    using CleanArchitecture.Application.Contracts.Persistence;

    public class CustomerQueryRepository : GenericRepository<CustomerQuery>, ICustomerQueryRepository
    {
        private readonly IMongoCollection<CustomerQuery> _customerQueryCollection;
        public CustomerQueryRepository(CustomerDbContext customerDbContext, IOptions<CustomerQuerySettings> customerQuerySettings) : base(customerDbContext)
        {
            var mongoClient = new MongoClient(customerQuerySettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(customerQuerySettings.Value.DatabaseName);
            _customerQueryCollection = mongoDatabase.GetCollection<CustomerQuery>(customerQuerySettings.Value.CustomerQueryCollectionName);
        }

        public void Add(CustomerQuery entity)
        {
            _customerQueryCollection.InsertOne(entity);
        }

        public async Task AddAsync(CustomerQuery entity)
        {
            await _customerQueryCollection.InsertOneAsync(entity);
        }

        public void Delete(CustomerQuery entity)
        {
            _customerQueryCollection.DeleteOne(x => x.Id == entity.Id);
        }

        public async Task DeleteAsync(CustomerQuery entity)
        {
            await _customerQueryCollection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public bool Exists(Guid id)
        {
            var result = _customerQueryCollection.Find(x => x.Id == id).FirstOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var result  = await _customerQueryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                return false;
            return true;
        }

        public CustomerQuery Get(Guid id)
        {
            return _customerQueryCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public IReadOnlyList<CustomerQuery> GetAll()
        {
            return _customerQueryCollection.Find(_ => true).ToList();
        }

        public async Task<IReadOnlyList<CustomerQuery>> GetAllAsync()
        {
            return await _customerQueryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<CustomerQuery> GetAsync(Guid id)
        {
            return await _customerQueryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerQuery>> GetQueryByCustomerId(Guid customerId)
        {
            var response = await _customerQueryCollection.FindAsync(x => x.CustomerId == customerId);
            return response.ToEnumerable();
        }

        public void Update(CustomerQuery entity)
        {
            _customerQueryCollection.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public async Task UpdateAsync(CustomerQuery entity)
        {
            await _customerQueryCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
    }
}
