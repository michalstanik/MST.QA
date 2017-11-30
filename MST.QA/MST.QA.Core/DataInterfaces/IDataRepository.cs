﻿using System.Collections.Generic;

namespace MST.QA.Core.DataInterfaces
{
    public interface IDataRepository
    {
        
    }

    public interface IDataRepository<T> : IDataRepository
    where T : class, IIdentifiableEntity, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(int id);

        T Update(T entity);

        IEnumerable<T> Get();

        T Get(int id);
    }
}
