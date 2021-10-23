using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.UnitOfWorkRepositories;
using System.Web.Http;
using AutoMapper;
using Data.DTOs;
using Data.Entities;
using System.Net;

namespace WebApi_2.Controllers
{
    public class BodiesController : ApiController
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public BodiesController(IUnitOfWorkRepository unitOfWorkRepository, AutoMapper.IMapper mapper)
        {
            this._unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        // GET: api/Bodies
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var bodies = await _unitOfWorkRepository.Bodies.GetAllAsync();

            if (bodies == null) return NotFound();

            var bodyDTOs = _mapper.Map<IEnumerable<BodyDTO>>(bodies);

            return Ok(bodyDTOs);
        }

        // GET: api/Bodies/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var body = await _unitOfWorkRepository.Bodies.GetAsync(c => c.Id == id, new List<string> { "Component", "Region"});

            if (body == null) return NotFound();

            var bodyDTO = _mapper.Map<BodyDetailDTO>(body);

            return Ok(bodyDTO);
        }

        // POST: api/Bodies
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ManageBodyDTO request)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid create attempt. Please try again!");

            try
            {
                var body = _mapper.Map<Body>(request);

                body.CreatedAt = DateTime.Now;
                body.UpdatedAt = DateTime.Now;

                _unitOfWorkRepository.Bodies.Create(body);
                await _unitOfWorkRepository.Save();

                var bodyDTO = _mapper.Map<BodyDTO>(body);

                return CreatedAtRoute("DefaultApi", new { id = bodyDTO.Id }, bodyDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Bodies/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] ManageBodyDTO request)
        {
            if (id < 1 || !ModelState.IsValid) return BadRequest("Invalid update attempt. Please try again!");

            try
            {
                var body = await _unitOfWorkRepository.Bodies.GetAsync(c => c.Id == id);

                if (body == null) return NotFound();

                var bodyForUpdate = _mapper.Map(request, body);

                // Update the updated time for the entity
                bodyForUpdate.UpdatedAt = DateTime.Now;

                _unitOfWorkRepository.Bodies.Update(bodyForUpdate);
                await _unitOfWorkRepository.Save();

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Bodies/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest("Invalid delete attempt. Please try again!");

            try
            {
                var body = await _unitOfWorkRepository.Bodies.GetAsync(c => c.Id == id);

                if (body == null) return NotFound();

                await _unitOfWorkRepository.Bodies.DeleteAsync(id);
                await _unitOfWorkRepository.Save();

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
