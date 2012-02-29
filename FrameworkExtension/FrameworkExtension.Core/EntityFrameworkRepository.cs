﻿using System;
using System.Linq;

namespace FrameworkExtension.Core
{
    public class EntityFrameworkRepository : IRepository
    {
        public EntityFrameworkRepository(IDbContext context)
        {
            Context = context;
        }

        public static IRepository Create<T>() where T : IDbContext
        {
            return Create<T>(string.Empty);
        }

        public static IRepository Create<T>(string connectionString) where T : IDbContext
        {
            if (!String.IsNullOrWhiteSpace(connectionString))
            {
                var contructors = typeof(T).GetConstructors();
                foreach (var constructorInfo in contructors)
                {
                    //Not Needed Yet
                    if (constructorInfo.GetParameters().Length == 1 &&
                        constructorInfo.GetParameters()[0].ParameterType == typeof(string))
                        return new EntityFrameworkRepository((IDbContext)constructorInfo.Invoke(new[] { connectionString }));
                }
            }
            return new EntityFrameworkRepository(Activator.CreateInstance<T>());
        }

<<<<<<< HEAD
        public IDbContext Context { get; private set; }
    }
=======
        public void Find<TType>(IQuery<TType> query)
        {
            Context.AsQueryable<TType>();
        }

        public IDbContext Context { get; set; }
    }

    public interface IQuery<T>
    {
    }
>>>>>>> master
}