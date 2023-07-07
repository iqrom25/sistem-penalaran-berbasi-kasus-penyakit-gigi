using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PBK_dita.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<TModel> Save(TModel model)
        {
            try
            {
                var newModel = await _db.Set<TModel>().AddAsync(model);
                await _db.SaveChangesAsync();
                return newModel.Entity;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }


        }

        public async Task<TModel> FindById(int id)
        {
            return await  _db.Set<TModel>().FindAsync(id);

        }

        public  async Task<IEnumerable<TModel>> FindByGroup(Expression<Func<TModel, bool>> predicate, string[] includes = null)
        {
            if(includes is null)
                return await _db.Set<TModel>().Where(predicate).ToListAsync();
            
            IQueryable<TModel> db = _db.Set<TModel>();
            foreach (var include in includes)
            {
                db = db.Include(include);
            }
            return await db.Where(predicate).ToListAsync();
        }

        public async Task<bool> CheckIfExist(Expression<Func<TModel, bool>> predicate)
        {
            return await _db.Set<TModel>().AnyAsync(predicate);
            
            
        }

        public async Task<TModel> FindBy(Expression<Func<TModel, bool>> predicate,string[] includes = null)
        {
            if(includes is null)
                return await _db.Set<TModel>().FirstOrDefaultAsync(predicate);
            
            IQueryable<TModel> db = _db.Set<TModel>();
            foreach (var include in includes)
            {
                db = db.Include(include);
            }
            return await db.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TModel>> FindAll(string[] includes = null)
        {
            if(includes is null)
                return await _db.Set<TModel>().ToListAsync();

            IQueryable<TModel> db = _db.Set<TModel>();
            foreach (var include in includes)
            {
                db = db.Include(include);
            }
            return await db.ToListAsync();
        }

        public async Task<TModel> Update(TModel model)
        {
            _db.Set<TModel>().Update(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task Delete(TModel model)
        {

            _db.Set<TModel>().Attach(model);
            _db.Set<TModel>().Remove(model);
            await _db.SaveChangesAsync();
        }
        
        public void detach(TModel entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }
    }
}