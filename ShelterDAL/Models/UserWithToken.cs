using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class UserWithToken : Volonter
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public static object Token { get; set; }

        public UserWithToken(Volonter user)
        {
            this.Idvolonters = user.Idvolonters;
            this.EMail = user.EMail;
            this.FirstName = user.FirstName;

            this.LastName = user.LastName;

            this.PhoneNamber = user.PhoneNamber;

            this.Role = user.Role;
        }
    }
}
