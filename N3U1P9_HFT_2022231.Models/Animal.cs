using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int animalId { get; set; }

        [Required, StringLength(30)]
        public string animalName { get; set; }

        [Required, Range(1,20)]
        public int animalAge { get; set; }

        [Required, ForeignKey(nameof(Shelter))]
        public int shelterId { get; set; }
    }
}
