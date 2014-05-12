using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Portfolio.Business
{
    public class MyContextManager<C> : IDisposable where C : global::System.Data.Linq.DataContext
    {
        public static ContextManager<C> GetManager(string database){
            bool IsAzureAvailable = false;
            try
            {
                IsAzureAvailable = RoleEnvironment.IsAvailable;
            }
            catch (Exception) { }

            if (IsAzureAvailable )
            {
                return ContextManager<C>.GetManager(RoleEnvironment.GetConfigurationSettingValue(database), false);
            }
            else
            {
                return ContextManager<C>.GetManager(database);
            }
        }

        public void Dispose()
        {
        }
    }
}
