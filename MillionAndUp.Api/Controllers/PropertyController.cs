using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Models.Interfaces;
using MillionAndUp.Models.Models.ValueObject;
using System;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Controllers
{
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyBLL _property;

        public PropertyController(IPropertyBLL property) => this._property = property;

        [HttpPost]
        [Route("api/RegisterProperty")]
        public async Task<IActionResult> RegisterProperty(PropertyDetail req)
        {
            try
            {
                _property.RegisterProperty(req);
                return Accepted();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetPropertyByOwner")]
        public async Task<IActionResult> GetPropertyByOwner(int ownerId)
        {
            try
            {
                return Ok((object)this._property.GetPropertyByOwner(ownerId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/GeneratePropertyTrace")]
        public async Task<IActionResult> GeneratePropertyTrace(PropertyTraceDetail req)
        {
            try
            {
                _property.GeneratePropertyTrace(req);
                return Accepted();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetImagesByProperty")]
        public async Task<IActionResult> GetImagesByProperty(int PropertyId)
        {
            try
            {
                _property.GetImagesByProperty(PropertyId);
                return Accepted();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/ListTrace")]
        public async Task<IActionResult> ListTrace(int PropertyId)
        {
            try
            {
                return Ok((object)this._property.ListTrace(PropertyId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/ModifyImagesProperty")]
        public async Task<IActionResult> ModifyImagesProperty(PropertyImageDetail req)
        {
            try
            {
                _property.ModifyImagesProperty(req);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
