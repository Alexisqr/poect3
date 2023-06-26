using ShelterDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Repositories
{
    public interface IUnitOfWorks
    {
        IGoodRepository GoodRepository { get;}
     
        void Commit();
        void Dispose();
        Task SeveChangesAsync();
    }
}
