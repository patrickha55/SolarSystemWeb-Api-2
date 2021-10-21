using Repository.UnitOfWorkRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi_2.Controllers
{
    public class RegionsController : ApiController
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        
        public RegionsController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        // GET: api/Regions
        public async Task<IHttpActionResult> Get()
        {
            var regions = await _unitOfWorkRepository.Regions.GetAllAsync();

            if (regions is null) return NotFound();

            return Ok(regions.ToList());
        }

        // GET: api/Regions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Regions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Regions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Regions/5
        public void Delete(int id)
        {
        }
    }
}
