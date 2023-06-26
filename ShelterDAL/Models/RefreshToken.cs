using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
   
        public partial class RefreshToken
        {
            public int TokenId { get; set; }
            public int UserId { get; set; }
            public string Token { get; set; }
            public DateTime ExpiryDate { get; set; }

            public virtual Volonter Volonter { get; set; }
        }
    
}
