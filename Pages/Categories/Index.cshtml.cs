using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bumbac_Daniela_Lab2.Data;
using Bumbac_Daniela_Lab2.Models;
using Bumbac_Daniela_Lab2.Models.ViewModels;

namespace Bumbac_Daniela_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Bumbac_Daniela_Lab2.Data.Bumbac_Daniela_Lab2Context _context;

        public IndexModel(Bumbac_Daniela_Lab2.Data.Bumbac_Daniela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoryBooks CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? BookID)
        {
            CategoryData = new CategoryBooks();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)


                 .ThenInclude(c => c.Book)
                 .ThenInclude(d => d.Author)
                .OrderBy(i => i.CategoryName)
               .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories
                                .Select(bc => bc.Book);
            }
        }
    }
}

