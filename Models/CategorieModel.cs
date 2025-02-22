namespace ProiectMedii.Models
{
    public class CategorieModel
    {
        public int ID { get; set; }
        public int ModelID { get; set; }
        public Clasa_model Model { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
