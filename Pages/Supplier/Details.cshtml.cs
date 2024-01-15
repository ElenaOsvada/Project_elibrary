using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Project_elibrary.Pages.Supplier
{
    public class DetailsModel : PageModel
    {
        private readonly Data.Project_elibraryContext _context;

        public DetailsModel(Data.Project_elibraryContext context)
        {
            _context = context;
        }

        internal Pages_Supplier_Index Supplier { get; set; } = default!;

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
                return Page();
            }
        }
    }
}
