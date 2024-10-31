using LandCaster.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.PortableExecutable;
using LandCaster.Entities.Specfications;
using LandCaster.Entities.DTOs;
using System.ComponentModel;


namespace LandCaster.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    { 
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();             
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public async Task<TEntity> Find(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> Finds(string id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> Fisrt(Expression<Func<TEntity, bool>> filter = null,
            string relationships = null, bool isTracking = true)
        {

            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);   //  select /* from where ....
            }
            if (relationships != null)
            {
                foreach (var incluirProp in relationships.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }


        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string relationships = null, bool isTracking = true, bool withTrashed = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);   //  select /* from where ....
            }
            if (relationships != null)
            {
                foreach (var incluirProp in relationships.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }
            if (withTrashed)
            {
                query = query.IgnoreQueryFilters();
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<PagedList<TEntity>> PaginateGetAsync(PaginationDTO parameters,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string relationships = null,
            bool isTracking = true,
            bool withTrashed = false)
        {
            IQueryable<TEntity> query = _dbSet;

            // Aplicar filtro
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Incluir relaciones si se especifican
            if (!string.IsNullOrEmpty(relationships))
            {
                foreach (var includeProp in relationships.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            // Incluir registros eliminados si se solicita
            if (withTrashed)
            {
                query = query.IgnoreQueryFilters();
            }

            // Ordenar si se especifica
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Desactivar seguimiento si se solicita
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            // Obtener la consulta en forma de string para depuración
            var queryString = query.ToQueryString();
            Console.WriteLine(queryString);

            // Ejecutar la consulta de manera asíncrona y paginar los resultados
            var pagedList = await PagedList<TEntity>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);

            return pagedList;
        }

    }
}
