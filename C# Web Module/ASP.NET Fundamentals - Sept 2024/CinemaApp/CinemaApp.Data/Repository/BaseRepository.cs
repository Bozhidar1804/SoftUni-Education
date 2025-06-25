using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Repository.Interfaces;
using System.Linq.Expressions;

namespace CinemaApp.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly CinemaDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public BaseRepository(CinemaDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            TType entity = this.dbSet.Find(id);
            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await this.dbSet.FindAsync(id);
            return entity;
        }

        public IEnumerable<TType> GetAll()
        {
            IEnumerable<TType> entities = this.dbSet.ToArray();
            return entities;
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            IEnumerable<TType> entities = await this.dbSet.ToArrayAsync();
            return entities;
        }

        public IQueryable<TType> GetAllAttached()
        {
            IQueryable<TType> entities = this.dbSet.AsQueryable();
            return entities;
        }

        public void Add(TType item)
        {
            this.dbSet.Add(item);
            this.dbContext.SaveChanges();
        }

        public async Task AddAsync(TType item)
        {
            await this.dbSet.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Delete(TType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TType entity)
        {
            this.dbSet.Remove(entity);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public bool Update(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
                this.dbContext.SaveChanges();

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType item)
        {
            try
            {
                this.dbSet.Attach(item);
                this.dbContext.Entry(item).State = EntityState.Modified;
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		public void AddRange(TType[] items)
		{
			this.dbSet.AddRange(items);
            this.dbContext.SaveChanges();
		}

		public async Task AddRangeAsync(TType[] items)
		{
			await this.dbSet.AddRangeAsync(items);
            await this.dbContext.SaveChangesAsync();
		}

		public void RemoveRange(TType[] items)
		{
			this.dbSet.RemoveRange(items);
            this.dbContext.SaveChanges();
		}

		public TType FirstOrDefault(Func<TType, bool> predicate)
		{
			TType entity = this.dbSet.FirstOrDefault(predicate);
            return entity;
		}

		public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
		{
			TType entity = await this.dbSet.FirstOrDefaultAsync(predicate);
            return entity;
		}
	}
}
