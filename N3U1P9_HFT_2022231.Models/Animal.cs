﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace N3U1P9_HFT_2022231.Models
{
    public class Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Species { get; set; }

        [Range(1,20)]
        public int Age { get; set; }

        [Required, ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        [JsonIgnore]
        public virtual Shelter Shelter { get; set; }

        public Animal() { }

    }
}
