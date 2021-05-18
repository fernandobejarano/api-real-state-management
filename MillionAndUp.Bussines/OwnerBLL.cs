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
    public class OwnerBLL : IOwnerBLL
    {
        private readonly SqlLiteDbContext _context;
        private readonly IMapper _mapper;
        public OwnerBLL(SqlLiteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateOwner(OwnerDetail req)
        {
            _context.Owner.Add(_mapper.Map<Owner>(req));
            _context.SaveChanges();
        }

        public IEnumerable<OwnerDetail> ListOwners()
        {
            var owners = _context.Owner.ToList();
            if (owners.Count <= 0)
                return null;
            return _mapper.Map<List<OwnerDetail>>(owners);
        }

        public async Task UpdateOwner(OwnerDetail req)
        {
            var owner = _context.Owner.Where(x => x.OwnerId == req.OwnerId).FirstOrDefault();
            owner = _mapper.Map<Owner>(req);
            _context.SaveChanges();
        }
    }
}
