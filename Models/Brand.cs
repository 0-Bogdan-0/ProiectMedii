namespace ProiectMedii.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string NumeBrand { get; set; }
        public ICollection<Clasa_model>? Modele { get; set; }
    }
}
