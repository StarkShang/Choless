using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Choless.Core.Brands;
using Choless.Core.Managers;
using Choless.Server.Commons;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : Controller
    {
        /// <summary>
        /// Create a brande
        /// </summary>
        /// <param name="brand">the content of the brand created</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AnonymousCreateBrandAsync([FromBody]Brand brand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var b = await _manager.AnonymousCreateBrandAsync(brand);
            return Created($"{Configuration.HostAddress}/brands/{b.Id}", brand.Id);
        }

        /// <summary>
        /// Delete a brand by its id
        /// </summary>
        /// <param name="id">the id of the brand deleted</param>
        /// <returns>HTTP Status: Ok(200) / NoContent(204)</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandByIdAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var b = await _manager.DeleteBrandByIdAsync(id);
            return b == null ? NotFound() : Ok() as IActionResult;
        }

        /// <summary>
        /// Modify a brand by its id and with its object
        /// </summary>
        /// <param name="id">the id of the brand modified</param>
        /// <param name="brand">the content of the brand modified</param>
        [HttpPatch("{id}")]
        public async Task<IActionResult> ModifyBrandByIdAsync(int id, [FromBody] Brand brand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (brand != null) return NoContent();

            var b = await _manager.ModifyBrandByIdAsync(id, brand);
            return b == null ? NotFound() : Ok() as IActionResult;
        }

        /// <summary>
        /// Replace a whole brand object by its id and with its object
        /// </summary>
        /// <param name="id">the id of the brand replaced</param>
        /// <param name="brand">the content of the brand replaced</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ReplaceBrandByIdAsync(int id, [FromBody] Brand brand)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (brand != null) return NoContent();

            var b = await _manager.ReplaceBrandByIdAsync(id, brand);
            return b == null ? NotFound() : Ok() as IActionResult;
        }

        /// <summary>
        /// Get all brands paged by param 'page'
        /// </summary>
        /// <param name="page">the index of page queried</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync([FromQuery]int page = 1)
        {
            return Json(await _manager.GetBrandsAsync(page));
        }

        /// <summary>
        /// Get a brand by its id
        /// </summary>
        /// <param name="id">the id of the brand queried</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandByIdAsync(string id)
        {
            return Json(await _manager.GetBrandByIdAsync(id));
        }
        

        private BrandManager _manager;
    
        public BrandController(BrandManager manager)
        {
            _manager = manager;
        }
    }
}
