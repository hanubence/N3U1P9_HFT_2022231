using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace N3U1P9_HFT_2022231.Models
{
    public class ShelterWorker
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Occupation { get; set; }

        [Range(1, 20)]
        public int Age { get; set; }

        [DataType(nameof(DateTime))]
        public DateTime HireDate;

        [Range(0,1000000)]
        public int Salary { get; set; }

        [Required, ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        [JsonIgnore]
        public virtual Shelter Shelter { get; private set; }

        public ShelterWorker() { }

    }
}
