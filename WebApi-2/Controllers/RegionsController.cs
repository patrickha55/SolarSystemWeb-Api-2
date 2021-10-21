using AutoMapper;
using Data.DTOs;
using Data.Entities;
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
        private readonly IMapper _mapper;
        
        public RegionsController(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        // GET: api/Regions
        public async Task<IHttpActionResult> Get()
        {
            var regions = await _unitOfWorkRepository.Regions.GetAllAsync();

            if (regions is null) return NotFound();

            var regionDTO = _mapper.Map<List<RegionDTO>>(regions);

            return Ok(regionDTO);
        }

        // GET: api/Regions/5
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id < 1) return BadRequest("Invalid id.");

            try
            {
                var region = await _unitOfWorkRepository.Regions.GetAsync(r => r.Id == id);

                if (region is null) return NotFound();

                var regionDTO = _mapper.Map<RegionDTO>(region);

                return Ok(regionDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/Regions
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]ManageRegionDTO request)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid create attempt. Please try again!");

            try
            {
                var region = _mapper.Map<Region>(request);
                region.CreatedAt = DateTime.Now;
                region.UpdatedAt = DateTime.Now;

                _unitOfWorkRepository.Regions.Create(region);
                await _unitOfWorkRepository.Save();

                var regionDTO = _mapper.Map<RegionDTO>(region);

                return CreatedAtRoute("DefaultApi", new { id = region.Id }, regionDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
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
