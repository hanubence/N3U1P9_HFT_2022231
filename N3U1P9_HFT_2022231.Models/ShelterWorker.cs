using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class ShelterWorker
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; set; }

        [Required, StringLength(30)]
        public string WorkerName { get; set; }

        [StringLength(30)]
        public string WorkerOccupation { get; set; }

        [Range(1, 20)]
        public int WorkerAge { get; set; }

        [DataType(nameof(DateTime))]
        public DateTime HireDate;

        [Required, ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; private set; }

        public ShelterWorker() { }

        public ShelterWorker(string data)
        {
            string[] splitData = data.Split(';');
            WorkerId = int.Parse(splitData[0]);
            WorkerName = splitData[1];
            WorkerOccupation = splitData[2];
            WorkerAge = int.Parse(splitData[3]);
            HireDate = DateTime.Parse(splitData[4]);
            ShelterId = int.Parse(splitData[5]);
        }
    }
}
