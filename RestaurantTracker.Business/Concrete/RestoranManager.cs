using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantTracker.Business.Abstract;
using RestaurantTracker.DataAccess.Abstract;
using RestaurantTracker.Entities;

namespace RestaurantTracker.Business.Concrete
{
    public class RestoranManager : IRestoranService
    {
        private IRestoranTrackerRepository _restoranRepository;

        public RestoranManager(IRestoranTrackerRepository restoranTrackerRepository)
        {
            _restoranRepository = restoranTrackerRepository;
        }

        public async Task<Restoran> CreateRestoran(Restoran restoran)
        {
            return await _restoranRepository.CreateRestoran(restoran);
        }

        public async Task<Restoran> DeleteRestoran(int id)
        {
            return await _restoranRepository.DeleteRestoran(id);
        }

        public async Task<List<Restoran>> GetAllRestorans()
        {
            return await _restoranRepository.GetAllRestorans();
        }

        public async Task<Restoran> GetById(int id)
        {
            return await _restoranRepository.GetById(id);
        }

        public async Task<Restoran> UpdateRestoran(Restoran restoran)
        {
            return await _restoranRepository.UpdateRestoran(restoran);
        }
    }
}