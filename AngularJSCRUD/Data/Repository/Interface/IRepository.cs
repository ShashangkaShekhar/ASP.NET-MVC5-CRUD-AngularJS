using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSCRUD.Data.Repository.Interface
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters);
        T ExecuteQuerySingle(string spQuery, object[] parameters);
        int ExecuteCommand(string spQuery, object[] parameters);
    }
}