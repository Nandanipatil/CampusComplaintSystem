using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusComplaintSystem.Data;
using CampusComplaintSystem.Models;

namespace CampusComplaintSystem.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Complaints (List all complaints)
        public async Task<IActionResult> Index()
        {
            var complaints = await _context.Complaints.ToListAsync();
            return View(complaints);
        }

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var complaint = await _context.Complaints.FirstOrDefaultAsync(m => m.Id == id);
            if (complaint == null) return NotFound();

            return View(complaint);
        }

        // GET: Complaints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complaints/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Category")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                complaint.Status = "Pending";
                complaint.CreatedAt = DateTime.Now;
                _context.Add(complaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null) return NotFound();

            return View(complaint);
        }

        // POST: Complaints/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,Status,CreatedAt")] Complaint complaint)
        {
            if (id != complaint.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Complaints.Any(e => e.Id == complaint.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var complaint = await _context.Complaints.FirstOrDefaultAsync(m => m.Id == id);
            if (complaint == null) return NotFound();

            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}