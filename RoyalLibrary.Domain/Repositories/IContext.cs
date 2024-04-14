using System;
using System.Data.Common;

namespace RoyalLibrary.Domain.Repositories.Interface
{
    public interface IContext : IDisposable
    {
        DbConnection Connection { get; }
    }
}
