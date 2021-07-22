using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Data
{
    public class BunRepository : IBunRepository
    {
        private BunContext _bunContext;
        private bool _disposed;

        public BunRepository()
        {
            _bunContext = new BunContext();
        }

        public void CreateBun(BunBase bun)
        {
            _bunContext.Buns.Add(bun);
        }

        public void Delete(int id)
        {
            var bun = _bunContext.Buns.Find(id);
            if (bun != null)
            {
                _bunContext.Buns.Remove(bun);
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _bunContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BunBase GetBun(int id)
        {
            return _bunContext.Buns.Find(id);
        }

        public IEnumerable<BunBase> GetBuns()
        {
            return _bunContext.Buns;
        }

        public void Save()
        {
            _bunContext.SaveChanges();
        }

        public void Update(BunBase bun)
        {
            _bunContext.Entry(bun).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
