using Data;
using Data.Entities;
using Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWorkRepositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationContext _context;
        private IGenericRepository<Region> _regions;
        private IGenericRepository<Component> _components;
        private IGenericRepository<Body> _bodies;

        public UnitOfWorkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IGenericRepository<Region> Regions => _regions is null ? new GenericRepository<Region>(_context) : _regions;
        public IGenericRepository<Component> Components => _components is null ? new GenericRepository<Component>(_context) : _components;
        public IGenericRepository<Body> Bodies => _bodies is null ? new GenericRepository<Body>(_context) : _bodies;

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
