using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class Shelter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shelterId { get; set; }

        public virtual ICollection<Animal> animals { get; set; }
        public virtual ICollection<ShelterWorker> workers { get; set; }

        [Required, StringLength(40)]
        public string shelterName { get; set; }

        [Required, StringLength(40)]
        public string shelterAddress { get; set; }

        [Required, Range(0,100000000)]
        public int annualBudget { get; set; }
    }
}
