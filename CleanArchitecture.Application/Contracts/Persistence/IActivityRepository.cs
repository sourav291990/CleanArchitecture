
namespace CleanArchitecture.Application.Contracts.Persistence;

using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities.Activity;

public interface IActivityRepository : IGenericRepository<Activity, DbContext>
{
}
