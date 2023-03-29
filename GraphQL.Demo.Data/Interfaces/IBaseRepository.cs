using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Interfaces
{
    public interface IBaseRepository<Tentity> : IDisposable
    {
        /// <summary>
        /// Persists the transaction to the data source.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
