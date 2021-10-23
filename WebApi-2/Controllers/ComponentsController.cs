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
    public class ComponentsController : ApiController
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public ComponentsController(IUnitOfWorkRepository unitOfWorkRepository, AutoMapper.IMapper mapper)
        {
            this._unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var components = await _unitOfWorkRepository.Components.GetAllAsync();

            if (components == null) return NotFound();

            var componentDTOs = _mapper.Map<IEnumerable<ComponentDTO>>(components);

            return Ok(componentDTOs);
        }

        // GET: api/Components/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var component = await _unitOfWorkRepository.Components.GetAsync(c => c.Id == id);

            if (component == null) return NotFound();

            var componentDTO = _mapper.Map<ComponentDTO>(component);

            return Ok(componentDTO);
        }

        // POST: api/Components
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ManageComponentDTO request)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid create attempt. Please try again!");

            try
            {
                var component = _mapper.Map<Component>(request);

                component.CreatedAt = DateTime.Now;
                component.UpdatedAt = DateTime.Now;

                _unitOfWorkRepository.Components.Create(component);
                await _unitOfWorkRepository.Save();

                var componentDTO = _mapper.Map<ComponentDTO>(component);

                return CreatedAtRoute("DefaultApi", new { id = componentDTO.Id }, componentDTO);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Components/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] ManageComponentDTO request)
        {
            if (id < 1 || !ModelState.IsValid) return BadRequest("Invalid update attempt. Please try again!");

            try
            {
                var component = await _unitOfWorkRepository.Components.GetAsync(c => c.Id == id);

                if (component == null) return NotFound();

                var componentForUpdate = _mapper.Map(request, component);

                // Update the updated time for the entity
                componentForUpdate.UpdatedAt = DateTime.Now;

                _unitOfWorkRepository.Components.Update(componentForUpdate);
                await _unitOfWorkRepository.Save();

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Components/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest("Invalid delete attempt. Please try again!");

            try
            {
                var component = await _unitOfWorkRepository.Components.GetAsync(c => c.Id == id);

                if (component == null) return NotFound();

                await _unitOfWorkRepository.Components.DeleteAsync(id);
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
