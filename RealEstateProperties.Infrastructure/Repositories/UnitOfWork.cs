using RealEstateProperties.Core.Interfaces;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateProperties.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstatePropertiesDBContext _realEstatePropertiesDBContext;
        public UnitOfWork(RealEstatePropertiesDBContext realEstatePropertiesDBContext)
        {
            _realEstatePropertiesDBContext = realEstatePropertiesDBContext;

        }

        #region Repositorios
        public IOwnerRepository OwnerRepository => new OwnerRepository(_realEstatePropertiesDBContext);
        public IPropertyImageRepository PropertyImageRepository => new PropertyImageRepository(_realEstatePropertiesDBContext);
        public IPropertyRepository PropertyRepository => new PropertyRepository(_realEstatePropertiesDBContext);
        public IPropertyTraceRepository PropertyTraceRepository => new PropertyTraceRepository(_realEstatePropertiesDBContext);
        #endregion 

        public void Dispose()
        {
            if (_realEstatePropertiesDBContext != null)
                _realEstatePropertiesDBContext.Dispose();
        }

        public void SaveChanges()
        {
            this._realEstatePropertiesDBContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._realEstatePropertiesDBContext.SaveChangesAsync();
        }
    }
}
