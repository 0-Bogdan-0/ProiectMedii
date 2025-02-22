using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace ProiectMedii.Models
{
    public class Clasa_model
    {
        public int ID { get; set; }
        public string Model { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPublicarii { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }

        public int? AgentID { get; set; }
        public Agent? Agent { get; set; }

        public ICollection<CategorieModel>? CategoriiModel { get; set; }
    }
}

