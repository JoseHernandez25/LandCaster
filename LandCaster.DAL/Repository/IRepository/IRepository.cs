using LandCaster.Entities.DTOs;
using LandCaster.Entities.Specfications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task<List<TEntity>> Get(Expression<Func<TEntity,bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                  string properties = null,
                        bool isTracking = true, bool withTrashed = false);

        void Delete(TEntity entity);
        void Update(TEntity entity);



        //metodos fuera del crud
        Task<TEntity> Find(int id);
        Task<TEntity> Finds(string id);

        Task<TEntity> Fisrt(Expression<Func<TEntity, bool>> filter = null,string properties = null,bool isTracking = true);

        Task<PagedList<TEntity>> PaginateGetAsync(PaginationDTO parameters, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string relationships = null,bool isTracking = true, bool withTrashed = false);
    }
}
