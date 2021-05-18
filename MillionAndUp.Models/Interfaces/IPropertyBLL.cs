using MillionAndUp.Models.Models.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Interfaces
{
    public interface IPropertyBLL
    {
        Task RegisterProperty(PropertyDetail req);
        IEnumerable<PropertyDetail> GetPropertyByOwner(int OwnerId);
        Task SaveImagesProperty(IEnumerable<PropertyImageDetail> req);
        Task ModifyImagesProperty(PropertyImageDetail req);
        IEnumerable<PropertyImageDetail> GetImagesByProperty(int PropertyId);
        Task GeneratePropertyTrace(PropertyTraceDetail req);
        IEnumerable<PropertyTraceDetail> ListTrace(int PropertyId);
    }
}
