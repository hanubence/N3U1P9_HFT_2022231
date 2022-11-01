using System;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Models;
using System.Linq;

namespace N3U1P9_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShelterDbContext context = new ShelterDbContext();

            var allatok = context.Animals.AsQueryable();


            ;
        }
    }
}
