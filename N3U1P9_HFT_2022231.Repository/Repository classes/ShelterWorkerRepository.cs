using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Repository.Repositories
{
    internal class ShelterWorkerRepository : Repository<ShelterWorker>, IRepository<ShelterWorker>
    {
        public ShelterWorkerRepository(ShelterDbContext ctx) : base(ctx) { }

        public override ShelterWorker Read(int id)
        {
            return this.ctx.Workers.First(t => t.WorkerId == id);
        }

        public override void Update(ShelterWorker item)
        {
            var o = Read(item.WorkerId);
            foreach (var prop in o.GetType().GetProperties())
            {
                prop.SetValue(o, prop.GetValue(item));
            }

            ctx.SaveChanges();
        }
    }
}
