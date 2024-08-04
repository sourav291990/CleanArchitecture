namespace CleanArchitecture.Persistence.Repositories;

using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Application.Contracts.Persistence;
public class ActivityRepository(CustomerDbContext customerDbContext) : GenericRepository<Activity>(customerDbContext), IActivityRepository
{
}
