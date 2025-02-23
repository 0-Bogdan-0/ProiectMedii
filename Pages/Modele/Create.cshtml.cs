using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Modele
{
    public class CreateModel : CategoriiModelPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "NumeBrand");
           
            ViewData["AgentID"] = new SelectList(_context.Agent.ToList(), "ID", "Nume");

            var model = new Clasa_model();
            model.CategoriiModel = new List<CategorieModel>();
            PopulateAssignedCategoryData(_context, model);

            return Page();

        }

        [BindProperty]
        public Clasa_model Clasa_model { get; set; } = default!;




        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newModel = new Clasa_model();
            if (selectedCategories != null)
            {
                newModel.CategoriiModel = new List<CategorieModel>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieModel
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newModel.CategoriiModel.Add(catToAdd);
                }
            }
            Clasa_model.CategoriiModel = newModel.CategoriiModel;
            _context.Clasa_model.Add(Clasa_model);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
