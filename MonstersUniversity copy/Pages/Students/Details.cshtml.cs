using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonstersUniversity.Data;
using MonstersUniversity.Models;

namespace MonstersUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly MonstersUniversity.Data.SchoolContext _context;

        public DetailsModel(MonstersUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

      public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

Student = await _context.Students
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);
    if (Student == null)
    {
        return NotFound();
    }
    return Page();
}
    }
}
