using ShelterBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterBLL.Services
{
    public interface IGoodResponceServic
    {
        public Task<GoodResponceDto> GetGood(int id);
    }
}
