﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DetailsModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public Categorie Categorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
