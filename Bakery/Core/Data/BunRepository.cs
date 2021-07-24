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

        public void CreateBun(Bun bun)
        {
            bun.Id = _bunContext.Buns.Count();
            _bunContext.Buns.Add(bun);
        }

        public void Delete(Bun bun)
        {
            var bunStored = _bunContext.Buns.Find(bun.Id);
            if (bunStored != null)
            {
                _bunContext.Buns.Remove(bunStored);
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

        public T GetBun<T>(int id)
            where T : Bun
        {
            return _bunContext.Buns.Find(id) as T;
        }

        public IEnumerable<Bun> GetBuns()
        {
            return _bunContext.Buns;
        }

        public void Save()
        {
            _bunContext.SaveChanges();
        }

        public void Update(Bun bun)
        {
            _bunContext.Entry(bun).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
