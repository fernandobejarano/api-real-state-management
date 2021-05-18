using AutoMapper;
using MillionAndUp.Models.Interfaces;
using MillionAndUp.Models.Models.Entity;
using MillionAndUp.Models.Models.ValueObject;
using MillionAndUp.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Bussines
{
    public class PropertyBLL : IPropertyBLL
    {
        private readonly SqlLiteDbContext _context;
        private readonly IMapper _mapper;
        public PropertyBLL(SqlLiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task RegisterProperty(PropertyDetail req)
        {
            _context.Property.Add(_mapper.Map<Property>(req));
            _context.SaveChanges();
        }
        public IEnumerable<PropertyDetail> GetPropertyByOwner(int OwnerId)
        {
            var propertys = _context.Property.Where(x => x.Owner.OwnerId == OwnerId).ToList();
            if (propertys.Count <= 0)
                return null;
            return _mapper.Map<IEnumerable<PropertyDetail>>(propertys);
        }

        public async Task SaveImagesProperty(IEnumerable<PropertyImageDetail> req)
        {
            _context.PropertyImage.Add(_mapper.Map<PropertyImage>(req));
            _context.SaveChanges();
        }

        public async Task ModifyImagesProperty(PropertyImageDetail req)
        {
            var owner = _context.PropertyImage.Where(x => x.Property.PropertyId == req.IdProperty).FirstOrDefault();
            owner = _mapper.Map<PropertyImage>(req);
            _context.SaveChanges();
        }
        public IEnumerable<PropertyImageDetail> GetImagesByProperty(int PropertyId)
        {
            var images = _context.PropertyImage.Where(x => x.Property.PropertyId == PropertyId).ToList();
            if (images.Count <= 0)
                return null;
            return _mapper.Map<IEnumerable<PropertyImageDetail>>(images);
        }

        public async Task GeneratePropertyTrace(PropertyTraceDetail req)
        {
            _context.PropertyTrace.Add(_mapper.Map<PropertyTrace>(req));
            _context.SaveChanges();
        }

        public IEnumerable<PropertyTraceDetail> ListTrace(int PropertyId)
        {
            var trace = _context.PropertyTrace.Where(x => x.Property.PropertyId == PropertyId).ToList();
            if (trace.Count <= 0)
                return null;
            return _mapper.Map<IEnumerable<PropertyTraceDetail>>(trace);
        }
    }
}
