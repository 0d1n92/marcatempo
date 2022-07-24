using System.Collections.Generic;

namespace api.Helpers;

public class PaginatedList<T>
{
    public int? Count { get; set; }
    public IEnumerable<T> Data { get; set; }
    public PaginatedList(int count, IEnumerable<T> data)
    {
        this.Count = count;
        this.Data = data;
    }
}