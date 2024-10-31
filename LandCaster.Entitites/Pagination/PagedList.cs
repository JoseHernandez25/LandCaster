using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Specfications
{
    public class PagedList<TEntity> : List<TEntity>
    {
        public MetaData MetaData { get; private set; }

        public PagedList(List<TEntity> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                CurrentPage = pageNumber,
                HasNext = pageNumber < (int)Math.Ceiling(count / (double)pageSize),
                HasPrevious = pageNumber > 1
            };
            AddRange(items);
        }

        public static async Task<PagedList<TEntity>> ToPagedListAsync(IQueryable<TEntity> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }

        public static PagedList<TEntity> ToPagedList(IQueryable<TEntity> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }
    }
}
