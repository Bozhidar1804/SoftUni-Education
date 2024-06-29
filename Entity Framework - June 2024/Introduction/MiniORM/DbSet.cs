using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
            }

            Entities.Add(entity);
            ChangeTracker.Add(entity);
        }

        public void Clear()
        {
            while(Entities.Any())
            {
                TEntity entityToRemove = Entities.First();
                Remove(entityToRemove);
            }
        }

        public bool Contains(TEntity item) { return Entities.Contains(item); }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
            }
            bool removedSuccessfully = Entities.Remove(entity);

            if (removedSuccessfully)
            {
                ChangeTracker.Remove(entity);
            }
            return removedSuccessfully;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities.ToArray())
            {
                Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }
}
