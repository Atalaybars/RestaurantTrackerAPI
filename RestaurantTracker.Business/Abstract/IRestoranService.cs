using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantTracker.Entities;

namespace RestaurantTracker.Business.Abstract
{
    public interface IRestoranService
    {
        Task<List<Restoran>> GetAllRestorans();
        Task<Restoran> GetById(int id);
        Task<Restoran> CreateRestoran(Restoran restoran);
        Task<Restoran> UpdateRestoran(Restoran restoran);
        Task<Restoran> DeleteRestoran(int id);
    }
}