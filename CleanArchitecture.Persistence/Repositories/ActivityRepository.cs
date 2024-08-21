namespace CleanArchitecture.Persistence.Repositories;

using CleanArchitecture.Persistence.DbContexts;
using CleanArchitecture.Domain.Entities.Activity;
using CleanArchitecture.Persistence.DbContextProvider;
using CleanArchitecture.Application.Contracts.Persistence;

public class ActivityRepository(IDbContextProvider dbContextProvider) : GenericRepository<Activity, ActivityDbContext>(dbContextProvider), IActivityRepository
{
}
