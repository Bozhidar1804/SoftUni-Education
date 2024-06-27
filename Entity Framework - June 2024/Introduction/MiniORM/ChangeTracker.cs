using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly IList<T> _added;
        private readonly IList<T> _removed;
        private readonly IList<T> _allEntities;

        public ChangeTracker(IEnumerable<T> entities)
        {
            _added = new List<T>();
            _removed = new List<T>();
            _allEntities = CloneEntities(entities);
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