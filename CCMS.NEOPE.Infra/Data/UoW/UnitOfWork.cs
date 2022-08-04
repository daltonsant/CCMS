using System.Data;
using System.Transactions;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CCMS.NEOPE.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public ITransaction BeginTransaction()
    {
        return new Transaction(_context);
    }
}