using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CCMS.NEOPE.Infra.Data.UoW;

public class Transaction: DbLoggerCategory.Database.Transaction, ITransaction
{
    private readonly IDbContextTransaction _transaction;
    private readonly ApplicationContext _context;

    public Transaction(ApplicationContext context)
    {
        _transaction = context.Database.BeginTransaction();
        _context = context;
    }
    
    public void Dispose()
    {
       _transaction.Dispose();
    }

    public void Commit()
    {
        _context.SaveChanges();
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }
}