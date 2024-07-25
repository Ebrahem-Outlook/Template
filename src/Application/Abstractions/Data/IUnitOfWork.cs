using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
