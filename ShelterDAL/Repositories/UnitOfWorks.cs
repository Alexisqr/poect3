using ShelterDAL.Models;
using ShelterEF.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Repositories
{
    public class UnitOfWorks : IUnitOfWorks, IDisposable
    {
    
        protected readonly AnShelterIdenContext databaseContext;

        public IGoodRepository GoodRepository { get; }

        public IGoodRepository Goodcom { get; }
        readonly IDbTransaction _dbTransaction;

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public Task SeveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public UnitOfWorks(
            AnShelterIdenContext databaseContext,

            IGoodRepository GoodManager,
            IDbTransaction dbTransaction

           )
        {
            this.databaseContext = databaseContext;

            Goodcom = GoodManager;
            _dbTransaction = dbTransaction;


        }
        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
