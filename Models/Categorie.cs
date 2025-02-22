namespace ProiectMedii.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieModel>? CategoriiModel { get; set; }
    }
}
