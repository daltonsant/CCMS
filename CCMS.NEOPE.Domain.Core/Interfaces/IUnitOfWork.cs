namespace CCMS.NEOPE.Domain.Core.Interfaces;

public interface IUnitOfWork
{
    ITransaction BeginTransaction();
}