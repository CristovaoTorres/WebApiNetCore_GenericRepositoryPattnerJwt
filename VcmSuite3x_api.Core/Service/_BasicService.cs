using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VcmSuite3x_api.Core.Service
{
    public static class IqueryableExtension
    {
        #region Extensions
        public static IQueryable<T> Paged<T>(this IQueryable<T> self, int? pageIndex = null, int? pageSize = null)
        {
            if (pageIndex.HasValue && pageSize.HasValue)
                return self.Skip(pageIndex.Value - 1).Take(pageIndex.Value);

            if (pageIndex.HasValue && !pageSize.HasValue)
                return self.Skip(pageIndex.Value - 1);

            if (!pageIndex.HasValue && pageSize.HasValue)
                return self.Take(pageIndex.Value);

            return self;

        }

        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                                 int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
        #endregion
    }

}
