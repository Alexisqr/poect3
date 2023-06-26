using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShelterDAL.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Repositories
{
    public class GoodRepository : GenericRepository<Good>, IGoodRepository
    {
        public GoodRepository(AnShelterIdenContext myContext, IDbTransaction dbtransaction) : base(myContext)
        {
        }

        public override Task<Good> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Good>> GetGood()
        {

            var results = await table.Include(project => project.Name)
                              .OrderByDescending(project => project.Id)
                              .Take(3)
                              .ToListAsync();

            return results;
        }
    
    }
}
