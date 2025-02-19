using System.ComponentModel.DataAnnotations;

namespace ProiectMedii.Models
{
    public class Agent
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nume { get; set; } = string.Empty;

    }
}
