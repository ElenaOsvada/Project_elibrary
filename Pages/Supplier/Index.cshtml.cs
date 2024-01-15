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
    public class IndexModel : PageModel
    {
        private readonly Project_elibrary.Data.Project_elibraryContext _context;

        public IndexModel(Project_elibrary.Data.Project_elibraryContext context)
        {
            _context = context;
        }

        internal IList<Pages_Supplier_Edit> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Supplier != null)
            {
                Supplier = (IList<Pages_Supplier_Edit>)await _context.Supplier.ToListAsync();
            }
        }
    }
}
