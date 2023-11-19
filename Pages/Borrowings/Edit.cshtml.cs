﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bumbac_Daniela_Lab2.Data;
using Bumbac_Daniela_Lab2.Models;

namespace Bumbac_Daniela_Lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Bumbac_Daniela_Lab2.Data.Bumbac_Daniela_Lab2Context _context;

        public EditModel(Bumbac_Daniela_Lab2.Data.Bumbac_Daniela_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
     .Include(b => b.Author)
     .Select(x => new
     {
         x.ID,
         BookFullName = x.Title + " - " + x.Author.LastName + " " +
    x.Author.FirstName
     });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
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

        private bool BorrowingExists(int id)
        {
          return (_context.Borrowing?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
