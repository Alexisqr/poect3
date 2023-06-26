using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterBLL.DTO;
using ShelterDAL.Repositories;
using ShelterEF.DAL.Repositories;

namespace ShelterBLL.Services
{
    public class GoodResponceServic : IGoodResponceServic
    {
        private readonly IUnitOfWorks _unitOfWork;

        public GoodResponceServic(IUnitOfWorks _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public async Task<GoodResponceDto> GetGood(int id)
        {
            var good = await _unitOfWork.GoodRepository.GetAsync(id);
            var goodResponceDto = new GoodResponceDto();
            goodResponceDto.Name = good.Name;
            
            goodResponceDto.Price = good.Price;
            goodResponceDto.Id = good.Id;

            return goodResponceDto;
        }
    }
}
