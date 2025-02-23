using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Modele
{
    public class EditModel : CategoriiModelPageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clasa_model Clasa_model { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Clasa_model = await _context.Clasa_model
                 .Include(b => b.Brand)
                 .Include(b => b.CategoriiModel).ThenInclude(b => b.Categorie)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            var clasa_model =  await _context.Clasa_model.FirstOrDefaultAsync(m => m.ID == id);
            if (clasa_model == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Clasa_model);
            Clasa_model = clasa_model;
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "NumeBrand");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelToUpdate = await _context.Clasa_model
            .Include(i => i.Brand)
            .Include(i => i.CategoriiModel)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (modelToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Clasa_model>(
            modelToUpdate,
            "Clasa_model",
            i => i.Model, i => i.Agent,
            i => i.Pret, i => i.DataPublicarii, i => i.BrandID))
            {
                UpdateModelCategories(_context, selectedCategories, modelToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateModelCategories(_context, selectedCategories, modelToUpdate);
            PopulateAssignedCategoryData(_context, modelToUpdate);
            return Page();
        }
    


        private bool Clasa_modelExists(int id)
        {
            return _context.Clasa_model.Any(e => e.ID == id);
        }
    }
}
