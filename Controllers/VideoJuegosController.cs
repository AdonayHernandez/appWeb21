using appWeb21.Data;
using appWeb21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appWeb21.Controllers
{
    public class VideoJuegosController : Controller
    {
        private readonly AppDbContext _context;

        public VideoJuegosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VideoJuegos
        public async Task<IActionResult> Index()
        {
            var juegos = await _context.VideoJuegos.ToListAsync();
            return View(juegos);
        }

        // GET: VideoJuegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var juego = await _context.VideoJuegos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (juego == null) return NotFound();

            return View(juego);
        }

        // GET: VideoJuegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoJuegos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoJuego juego)
        {
            if (!ModelState.IsValid)
                return View(juego);

            _context.VideoJuegos.Add(juego);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoJuegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var juego = await _context.VideoJuegos.FindAsync(id);
            if (juego == null) return NotFound();

            return View(juego);
        }

        // POST: VideoJuegos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VideoJuego juego)
        {
            if (id != juego.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.VideoJuegos.Any(e => e.Id == juego.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(juego);
        }

        // GET: VideoJuegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var juego = await _context.VideoJuegos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (juego == null) return NotFound();

            return View(juego);
        }

        // POST: VideoJuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juego = await _context.VideoJuegos.FindAsync(id);

            if (juego != null)
            {
                _context.VideoJuegos.Remove(juego);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
