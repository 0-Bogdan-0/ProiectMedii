﻿using System;
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
    public class CreateModel : PageModel
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
            return Page();
        }

        [BindProperty]
        public Clasa_model Clasa_model { get; set; } = default!;




        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                System.Diagnostics.Debug.WriteLine("Erori ModelState: " + errors);

                ViewData["ModelStateErrors"] = errors;

                return Page();
            }

            _context.Clasa_model.Add(Clasa_model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
