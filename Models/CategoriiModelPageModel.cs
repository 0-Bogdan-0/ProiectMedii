using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMedii.Data;
namespace ProiectMedii.Models
{
    public class CategoriiModelPageModel : PageModel
    {
        public List<CategorieAsignataData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectMediiContext context,
        Clasa_model Model)
        {
            var allCategories = context.Categorie;
            var CategoriiModel = new HashSet<int>(
            Model.CategoriiModel.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<CategorieAsignataData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new CategorieAsignataData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = CategoriiModel.Contains(cat.ID)
                });
            }
        }
        public void UpdateModelCategories(ProiectMediiContext context,
        string[] selectedCategories, Clasa_model modelToUpdate)
        {
            if (selectedCategories == null)
            {
                ModelToUpdate.CategoriiModel = new List<CategorieModel>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriiModel = new HashSet<int>
            (modelToUpdate.CategoriiModel.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriiModel.Contains(cat.ID))
                    {
                        modelToUpdate.CategoriiModel.Add(
                        new CategorieModel
                        {
                            ModelID = modelToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (categoriiModel.Contains(cat.ID))
                    {
                        CategorieModel bookToRemove
                        = modelToUpdate
                        .CategoriiModel
                       .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(ModelToRemove);
                    }
                }
            }
        }
    }