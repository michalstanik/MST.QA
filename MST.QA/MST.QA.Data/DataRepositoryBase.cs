using System.Collections.Generic;
using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;

namespace MST.QA.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, MSTQAContext>
        where T : class, IIdentifiableEntity, new()
    {

    }
}
