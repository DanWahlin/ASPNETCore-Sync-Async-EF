using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Sync_Async_EF.Models
{
    public struct PagingResult<T>
    {
        public IEnumerable<T> Records { get; set; }
        public int TotalRecords { get; set; }

        public PagingResult(IEnumerable<T> items, int totalRecords)
        {
            TotalRecords = totalRecords;
            Records = items;
        }
    }
}
