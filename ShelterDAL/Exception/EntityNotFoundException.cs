using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Exception
{
    public class EntityNotFoundException : IOException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException()
            : base()
        {
        }
    }
}
