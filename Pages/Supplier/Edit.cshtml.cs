using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_elibrary.Data;
using Project_elibrary.Models;

namespace Project_elibrary.Pages.Supplier
{
    public class EditModel : PageModel
    {
        private readonly Project_elibrary.Data.Project_elibraryContext _context;

        public EditModel(Project_elibrary.Data.Project_elibraryContext context)
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

            var supplier =  await _context.Supplier.FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            Supplier = supplier;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(Supplier.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupplierExists(int id)
        {
          return (_context.Supplier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
