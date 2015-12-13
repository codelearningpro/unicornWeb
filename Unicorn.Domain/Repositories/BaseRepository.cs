using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Concrete;

namespace Unicorn.Domain.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected SWSDbContext ctx;

        public BaseRepository(int userID)
        {
            ctx = new SWSDbContext();
            ctx.UserID = userID;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
