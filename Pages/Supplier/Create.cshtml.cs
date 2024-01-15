using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_elibrary.Data;
using Project_elibrary.Models;

namespace Project_elibrary.Pages.Supplier
{
    public class CreateModel : PageModel
    {
        private readonly Project_elibrary.Data.Project_elibraryContext _context;

        public CreateModel(Project_elibrary.Data.Project_elibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project_elibrary.Models.Supplier Supplier { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Supplier == null || Supplier == null)
            {
                return Page();
            }

            _context.Supplier.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
