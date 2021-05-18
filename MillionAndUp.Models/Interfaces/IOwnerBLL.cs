using MillionAndUp.Models.Models.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Interfaces
{
    public interface IOwnerBLL
    {
        Task CreateOwner(OwnerDetail req);
        IEnumerable<OwnerDetail> ListOwners();
        Task UpdateOwner(OwnerDetail req);
    }
}
