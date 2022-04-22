using System;
using System.Collections.Generic;
using System.Text;

namespace JahzeenApi.Domain.DTO
{
    public   class ListResponse<TEntity>
    {
        public List<TEntity> entities { get; set; }
        public int TotalCount { get; set; }
    }
}
