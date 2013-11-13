using Template.Core.Model.ValueObjects;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static PaginatedCollection<T> ToPaginatedCollection<T>(this IQueryable<T> query, Page page)
        {
            var ret = new PaginatedCollection<T>
            {
                Page = page,
                Collection = query.SelectPage(page).ToArray(),
                TotalRows = query.Count()
            };
            int rest;
            int pages = Math.DivRem(ret.TotalRows, ret.Page.Size, out rest);
            if (rest != 0)
                pages++;
            ret.QuantityPages = pages;

            return ret;
        }

        public static IQueryable<T> SelectPage<T>(this IQueryable<T> collection, Page page)
        {
            return collection.Skip((page.Number - 1) * page.Size).Take(page.Size);
        }
    }
}
