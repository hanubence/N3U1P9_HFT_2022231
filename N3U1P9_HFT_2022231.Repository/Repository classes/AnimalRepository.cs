﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Repository
{
    public class AnimalRepository : Repository<Animal>, IRepository<Animal>
    {
        public AnimalRepository(ShelterDbContext ctx) : base(ctx) { }

        public override Animal Read(int id)
        {
            return this.ctx.Animals.First(t => t.AnimalId == id);
        }

        public override void Update(Animal item)
        {
            var o = Read(item.AnimalId);
            foreach (var prop in o.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null && prop != null)
                {
                    prop.SetValue(o, prop.GetValue(item));
                }
            }

            ctx.SaveChanges();
        }
    }
}
