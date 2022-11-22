using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class Shelter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelterId { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<ShelterWorker> Workers { get; set; }

        [Required, StringLength(40)]
        public string ShelterName { get; set; }

        [StringLength(40)]
        public string ShelterAddress { get; set; }

        [Range(0,100000000)]
        public int AnnualBudget { get; set; }

        public Shelter()
        {
            Animals = new HashSet<Animal>();
            Workers = new HashSet<ShelterWorker>();
        }

        public Shelter(string data)
        {
            string[] splitData = data.Split(';');
            ShelterId = int.Parse(splitData[0]);
            ShelterName = splitData[1];
            ShelterAddress = splitData[2];
            AnnualBudget = int.Parse(splitData[3]);

            Animals = new HashSet<Animal>();
            Workers = new HashSet<ShelterWorker>();
        }
    }
}
