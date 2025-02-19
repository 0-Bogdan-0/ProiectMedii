using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Modele
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Clasa_model> Clasa_model { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Clasa_model = await _context.Clasa_model
                .Include(b => b.Brand)
                .Include(m => m.Agent)
                .ToListAsync();
        }
    }
}
