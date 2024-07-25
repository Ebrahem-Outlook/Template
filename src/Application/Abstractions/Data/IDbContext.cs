using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
