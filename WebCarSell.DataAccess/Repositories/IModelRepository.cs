using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarSell.DataAccess.Entities;

namespace WebCarSell.DataAccess.Repositories
{
    public interface IModelRepository
    {
        Task<Guid> GetUserId(string name);
        Task<List<Model>> GetModelsByIdUser(Guid guid);
        Task<List<Model_Modifications>> GetModificationsByIdUser(Guid guid);
        Task<int> GetPriceOfModificationByIdModification(string name);
    }
}
