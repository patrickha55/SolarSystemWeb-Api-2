using Data.Entities;
using Repository.GenericRepositories;
using System;
using System.Threading.Tasks;

namespace Repository.UnitOfWorkRepositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IGenericRepository<Region> Regions { get; }
        IGenericRepository<Component> Components { get; }
        IGenericRepository<Body> Bodies { get; }

        Task Save();
    }
}
