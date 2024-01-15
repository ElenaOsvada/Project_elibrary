using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_elibrary.Data;
using Project_elibrary.Models;

namespace Project_elibrary.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Project_elibrary.Data.Project_elibraryContext _context;

        public IndexModel(Project_elibrary.Data.Project_elibraryContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }
    }
}
