using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly IList<T> _added; // Tracks added entities (to be added)
        private readonly IList<T> _removed; // Tracks removed entities (to be removed)
        private readonly IList<T> _allEntities; // Tracks the updates of the entities

        public ChangeTracker(IEnumerable<T> entities)
        {
            _added = new List<T>();
            _removed = new List<T>();
            _allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => (IReadOnlyCollection<T>)_allEntities;
        public IReadOnlyCollection<T> Added => (IReadOnlyCollection<T>)_added;
        public IReadOnlyCollection<T> Removed => (IReadOnlyCollection<T>)_removed;

        public void Add(T item)
        {
            _added.Add(item);
        }

        public void Remove(T item)
        {
            _removed.Add(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            IList<T> modifiedEntities = new List<T>();
            PropertyInfo[] primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }
            return modifiedEntities;
        }

        private bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));
            PropertyInfo[] modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();
            return modifiedProperties.Any();
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private static IList<T> CloneEntities(IEnumerable<T> entities)
        {
            IList<T> clonedEntities = new List<T>();
            PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
                            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                            .ToArray();
            
            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }
    }
}