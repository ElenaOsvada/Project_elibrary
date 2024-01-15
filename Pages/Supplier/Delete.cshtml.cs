using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_elibrary.Data;
using Project_elibrary.Models;

namespace Project_elibrary.Pages.Supplier
{
    public class DeleteModel : PageModel
    {
        private readonly Project_elibrary.Data.Project_elibraryContext _context;

        public DeleteModel(Project_elibrary.Data.Project_elibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Project_elibrary.Models.Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.Id == id);

            if (supplier == null)
            {
                return NotFound();
            }
            else 
            {
                Supplier = supplier;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }
            var supplier = await _context.Supplier.FindAsync(id);

            if (supplier != null)
            {
                Supplier = supplier;
                _context.Supplier.Remove(Supplier);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
