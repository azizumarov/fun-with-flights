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

        public int Skip { get; set; }
        public int Take { get; set; }
        public long TotalCount { get; set; }

        public PagedResult(List<TValue> result, int skip, int take,  long totalCount)
        {
            Result = result;
            Skip = skip;
            Take = take;
            TotalCount = totalCount;
        }
    }
}
