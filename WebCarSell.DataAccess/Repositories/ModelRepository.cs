using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Context;
using WebCarSell.DataAccess.Entities;

namespace WebCarSell.DataAccess.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationContext _dbContext;

        public ModelRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> GetUserId(string name)
        {
            var Id = await _dbContext.Users
                            .Where(x => x.UserName == name)
                            .Select(x => x.IdUser)
                            .FirstOrDefaultAsync();
            return Id;
        }
        public async Task<List<Model>> GetModelsByIdUser(Guid guid)
        {
            var models = await _dbContext.Models
                            .Where(x => x.UserId == guid)
                            .Select(x => x)
                            .ToListAsync();
            return models;
        }
        public async Task<int> GetPriceOfModificationByIdModification(string name)
        {
            var price = await _dbContext.Modifications
                .Where(x => x.Name == name)
                .Select(x => x.Price)
                .FirstOrDefaultAsync();
            return price;
        }
        public async Task<List<Model_Modifications>> GetModificationsByIdUser(Guid guid)
        {
            var models = await _dbContext.ModelModifications
                            .Where(x => x.ModelId == guid)
                            .Select(x => x)
                            .ToListAsync();
            return models;
        }
    }
}
