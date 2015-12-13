using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Unicorn.Domain.Entities;

namespace Unicorn.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        #region Public Properties   
        int UserID { get; set; }
        DbSet<Customer> Customer { get; set; }
        string ConnectionString { get; set; }
        #endregion
    }
}
