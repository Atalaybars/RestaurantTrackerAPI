using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using RestaurantTracker.DataAccess.Abstract;
using RestaurantTracker.Entities;

namespace RestaurantTracker.DataAccess.Concrete
{
    public class RestoranTrackerRepository : IRestoranTrackerRepository
    {
        private readonly string _connectionStr;

        public RestoranTrackerRepository(IConfiguration config)
        {
            _connectionStr = config.GetConnectionString("connectionString");
        }
        
        public async Task<Restoran> CreateRestoran(Restoran restoran)
        {
            var newRestoran = new
            {
                name = restoran.Name,
                address = restoran.Address,
                type_of_food = restoran.Type_of_Food
            };

            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                return await connection.QueryFirstOrDefaultAsync<Restoran>("CreateRestoran", newRestoran, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Restoran> DeleteRestoran(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                return await connection.QueryFirstOrDefaultAsync<Restoran>("DeleteRestoran", new { id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Restoran>> GetAllRestorans()
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                return (List<Restoran>)await connection.QueryAsync<Restoran>("GetAllRestorans", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Restoran> GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                return await connection.QueryFirstOrDefaultAsync<Restoran>("GetById", new { id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Restoran> UpdateRestoran(Restoran restoran)
        {
            var updatedRestoran = new
            {
                id = restoran.Id,
                name = restoran.Name,
                address = restoran.Address,
                type_of_food = restoran.Type_of_Food
            };

            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                return await connection.QueryFirstOrDefaultAsync<Restoran>("UpdateRestoran", updatedRestoran, commandType: CommandType.StoredProcedure);
            }
        }
    }
}