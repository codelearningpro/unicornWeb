using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Interfaces;

namespace Unicorn.Domain.Entities
{
    public class Auditable : IAuditable
    {
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public int? UpdatedBy { get; set; }
      
        public void SetCreated(int userID)
        {
            this.CreatedBy = userID;
            this.Created = DateTime.Now;
        }

        public void SetUpdated(int userID)
        {
            this.UpdatedBy = userID;
            this.Updated = DateTime.Now;
        }
    }
}
