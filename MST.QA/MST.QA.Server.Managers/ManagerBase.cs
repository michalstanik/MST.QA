using MST.QA.Core.Data;
using System;
using System.ServiceModel;
using System.ComponentModel.Composition;

namespace MST.QA.Server.Managers
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            if(ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);
        }
        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
