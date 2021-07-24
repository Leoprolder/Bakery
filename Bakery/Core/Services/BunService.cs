using Bakery.Core.Data;
using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Services
{
    public class BunService : IBunService
    {
        private readonly IBunRepository _bunRepository;

        public BunService(IBunRepository bunRepository)
        {
            _bunRepository = bunRepository;
        }

        public void Add(Bun bun)
        {
            _bunRepository.CreateBun(bun);
            _bunRepository.Save();
        }

        public IEnumerable<Bun> GetAll()
        {
            return _bunRepository.GetBuns();
        }

        public T Get<T>(int id)
            where T : Bun
        {
            return _bunRepository.GetBun<T>(id);
        }

        public void Update(Bun bun)
        {
            _bunRepository.Update(bun);
            _bunRepository.Save();
        }

        public void Delete(Bun bun)
        {
            _bunRepository.Delete(bun);
        }
    }
}
