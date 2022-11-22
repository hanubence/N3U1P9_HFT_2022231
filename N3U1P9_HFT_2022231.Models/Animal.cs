using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Required, StringLength(30)]
        public string AnimalName { get; set; }

        [StringLength(20)]
        public string AnimalType { get; set; }

        [Range(1,20)]
        public int AnimalAge { get; set; }

        [Required, ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; private set; }

        public Animal()
        {

        }

        public Animal(string data)
        {
            string[] splitData = data.Split(';');
            AnimalId = int.Parse(splitData[0]);
            AnimalName = splitData[1];
            AnimalType = splitData[2];
            AnimalAge = int.Parse(splitData[3]);
            ShelterId = int.Parse(splitData[4]);
        }
    }
}
