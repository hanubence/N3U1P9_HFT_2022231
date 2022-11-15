using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Repository.Repositories
{
    internal class ShelterRepository : Repository<Shelter>, IRepository<Shelter>
    {
        public ShelterRepository(ShelterDbContext ctx) : base(ctx) { }

        public override Shelter Read(int id)
        {
            return this.ctx.Shelters.First(t => t.ShelterId == id);
        }

        public override void Update(Shelter item)
        {
            var o = Read(item.ShelterId);
            foreach (var prop in o.GetType().GetProperties())
            {
                prop.SetValue(o, prop.GetValue(item));
            }

            ctx.SaveChanges();
        }
    }
}
