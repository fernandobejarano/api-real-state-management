using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Models.Interfaces;
using MillionAndUp.Models.Models.ValueObject;
using System;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Controllers
{
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerBLL _owner;

        public OwnerController(IOwnerBLL owner) => this._owner = owner;

        [HttpPost]
        [Route("api/CreateOwner")]
        public async Task<IActionResult> CreateOwner(OwnerDetail req)
        {
            try
            {
                _owner.CreateOwner(req);
                return Accepted();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/ListOwners")]
        [HttpGet]
        public async Task<IActionResult> ListOwners()
        {
            try
            {
                return Ok(_owner.ListOwners());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/UpdateOwner")]
        [HttpPut]
        public async Task<IActionResult> UpdateOwner(OwnerDetail req)
        {
            try
            {
                _owner.UpdateOwner(req);
                return Accepted();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
