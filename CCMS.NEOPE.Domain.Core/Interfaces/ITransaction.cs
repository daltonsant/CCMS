namespace CCMS.NEOPE.Domain.Core.Interfaces;

public interface ITransaction : IDisposable
{
    void Commit();
    void Rollback();
}