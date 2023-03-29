using GraphQL.Demo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private bool _disposed;
        public Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                Trace.TraceError(ex.Message);
                Exception innerException = ex;

                while (innerException.InnerException != null) innerException = innerException.InnerException;

                throw innerException;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Exception innerException = ex;

                while (innerException.InnerException != null) innerException = innerException.InnerException;

                throw innerException;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
