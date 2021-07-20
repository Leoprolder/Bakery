using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Data
{
    public class BunService : IBunService
    {
        private readonly IBunRepository<BunBase> _bunRepository;

        public BunService(IBunRepository<BunBase> bunRepository)
        {
            _bunRepository = bunRepository;
        }

        public void Add(BunBase bun)
        {
            _bunRepository.CreateBun(bun);
            _bunRepository.Save();
        }

        public IEnumerable<BunBase> GetAll()
        {
            return _bunRepository.GetBuns();
        }

        public BunBase Get(int id)
        {
            return _bunRepository.GetBun(id);
        }

        public void Update(BunBase bun)
        {
            _bunRepository.Update(bun);
            _bunRepository.Save();
        }

        public void Delete(int id)
        {
            _bunRepository.Delete(id);
            _bunRepository.Save();
        }
    }
}
