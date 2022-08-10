namespace CCMS.NEOPE.Domain.Core.Interfaces;

public interface IPagedList<T> : IList<T> where T : class
{
    int TotalCount { get; set; }
    int FilteredCount { get; set; }
}