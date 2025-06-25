using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();

        IQueryable<TType> GetAllAttached();
        
        void Add(TType item);
        Task AddAsync(TType item);

        void AddRange(TType[] items);
        Task AddRangeAsync(TType[] items);

        void RemoveRange(TType[] items);

        bool Delete(TType entity);
        Task<bool> DeleteAsync(TType entity);

        bool Update(TType item);
        Task<bool> UpdateAsync(TType item);

        TType FirstOrDefault(Func<TType, bool> predicate);

        Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);
    }
}
