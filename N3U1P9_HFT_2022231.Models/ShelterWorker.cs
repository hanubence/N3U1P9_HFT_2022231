using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N3U1P9_HFT_2022231.Models
{
    public class ShelterWorker
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int workerId { get; set; }

        [Required, StringLength(30)]
        public string workerName { get; set; }

        [Required, StringLength(30)]
        public string workerOccupation { get; set; }

        [Required, Range(1, 20)]
        public int workerAge { get; set; }

        [Required, DataType(nameof(DateTime))]
        public DateTime startDate;

        [Required, ForeignKey(nameof(Shelter))]
        public int shelterId { get; set; }

        public virtual Shelter shelter { get; private set; }

        public ShelterWorker() { }

        public ShelterWorker(string data)
        {
            string[] splitData = data.Split(';');
            workerId = int.Parse(splitData[0]);
            workerName = splitData[1];
            workerOccupation = splitData[2];
            workerAge = int.Parse(splitData[3]);
            startDate = DateTime.Parse(splitData[4]);
            shelterId = int.Parse(splitData[5]);
        }
    }
}
