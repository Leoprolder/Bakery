using Bakery.Core.Model.Bun;
using System.Collections.Generic;

namespace Bakery.Core.Services
{
    public interface IBunService
    {
        public void Add(Bun bun);

        public IEnumerable<Bun> GetAll();

        public T Get<T>(int id)
            where T : Bun;

        public void Delete(Bun bun);

        public void Update(Bun bun);
    }
}
