using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection;

namespace MiniORM
{
    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            dbSetProperties = DiscoverDbSets();
            using (new ConnectionManager(connection))
            {
                InitializeDbSets();
            }
            MapAllRelations();
        }

        public void SaveChanges()
        {
            object[] dbSets = dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach(IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEntitiesFound, invalidEntities.Count(), dbSet.GetType().Name));
                }
            }

            using(new ConnectionManager(connection))
            {
                using SqlTransaction transaction = connection.StartTransaction();
                
                    foreach (IEnumerable dbSet in dbSets)
                    {
                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)!
                            .MakeGenericMethod(dbSet.GetType());

                        try
                        {
                            try
                            {
                                persistMethod.Invoke(this, new object[] { dbSet });
                            } catch (TargetInvocationException e) when (e.InnerException != null)
                            {
                                throw e.InnerException;
                            }
                        } catch
                        {
                            Console.WriteLine("Rollback!!!");
                            transaction.Rollback();
                            throw;
                        }
                    }

                transaction.Commit();
                
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));
            var columns = connection.FetchColumnNames(tableName).ToArray();
            if (dbSet.ChangeTracker.Added.Any())
            {
                connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private void InitializeDbSets()
        {
            foreach (var dbSet in dbSetProperties)
            {
                var dbSetType = dbSet.Key;
                var dbSetProperty = dbSet.Value;

                var populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);
                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            var entities = LoadTableEntities<TEntity>();
            var dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in dbSetProperties)
            {

            }
        }

        private object GetTableName(Type type)
        {
            throw new NotImplementedException();
        }

        private bool IsObjectValid(object entity)
        {
            throw new NotImplementedException();
        }

        private Dictionary<Type, PropertyInfo[]>? DiscoverDbSets()
        {
            throw new NotImplementedException();
        }
    }
}
