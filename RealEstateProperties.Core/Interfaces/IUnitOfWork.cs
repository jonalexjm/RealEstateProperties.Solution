using RealEstateProperties.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOwnerRepository OwnerRepository { get; }
        IPropertyImageRepository PropertyImageRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
