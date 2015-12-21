using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unicorn.Domain.Entities
{
    public class CustomerSignIn : Auditable
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int SignInTypeID { get; set; }
        public string SignInName_hash { get; set; }
        public string SignInPassword_hash { get; set; }
        public DateTime StartDate { get; set; }
        public Guid Token { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string Status { get; set; }
        public int Sequence { get; set; }
    }
}
