using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWF.Core.Domain.Results
{
    public class PagedResult<TValue>
    {
        public List<TValue> Result { get; set; }
        public long TotalCount { get; set; }

        public PagedResult(List<TValue> result, long totalCount)
        {
            Result = result;
            TotalCount = totalCount;
        }

        public static PagedResult<TValue> Create(List<TValue> result, long totalCount)
        {
            return new PagedResult<TValue>(result, totalCount);
        }
    }
}
