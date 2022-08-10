

using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Infra.Customs;

public class PagedList<T> : List<T>, IPagedList<T> where T : class
{
    public PagedList(int totalRecords, int filteredCount, ICollection<T>? list)
    {
        if(list != null)
            this.AddRange(list);
        TotalCount = totalRecords;
        FilteredCount = filteredCount;
    }

    public int TotalCount { get; set; }
    public int FilteredCount { get; set; }
}



// using CCMS.NEOPE.Domain.Core.Models;
// using Microsoft.EntityFrameworkCore;
//
// namespace CCMS.NEOPE.Infra.Customs;
//
// public class PaginatedList<T> : List<T>
// {
//     public int PageIndex { get; private set; }
//     public int TotalPages { get; private set; }
//     private ulong _lastId { get;  set; }
//
//     public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, ulong lastId)
//     {
//         PageIndex = pageIndex;
//         TotalPages = (int)Math.Ceiling(count / (double)pageSize);
//         LastId = lastId;
//         
//         this.AddRange(items);
//     }
//
//     public bool HasPreviousPage => PageIndex > 1;
//
//     public bool HasNextPage => PageIndex < TotalPages;
//
//     public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, int lastId)
//     {
//         var nextPage = source
//             .OrderBy(b => b.Id)
//             .Where(b => b.Id > (ulong)lastId)
//             .Take(pageSize)
//             .ToListAsync();
//         
//         var count = await source.CountAsync();
//         
//         return new PaginatedList<T>(nextPage, count, pageIndex, pageSize);
//     }
// }