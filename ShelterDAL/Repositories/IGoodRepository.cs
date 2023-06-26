using ShelterDAL.Models;


namespace ShelterDAL.Repositories
{
    public interface IGoodRepository : IRepository<Good>
    {
        Task<IEnumerable<Good>> GetGood();
    }
}