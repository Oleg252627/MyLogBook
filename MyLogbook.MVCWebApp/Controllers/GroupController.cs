using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLogbook.Entities;
using MyLogbook.MVCWebApp.Models;
using MyLogbook.Repositories;

namespace MyLogbook.MVCWebApp.Controllers
{
    public class GroupController : Controller
    {
        private IGroupRepository _repository;
        private IFacultyRepository _facultyRepository;

        public GroupController(IGroupRepository repository, IFacultyRepository facultyRepository)
        {
            _repository = repository;
            _facultyRepository = facultyRepository;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            
            var data = await _repository.AllItems.Include(group => group.Faculty).ToListAsync();
            return View(data);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _repository.AllItems.Include(group => group.Faculty).FirstOrDefaultAsync(x => x.Id==id.Value);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.faculty = await _facultyRepository.ShowFaculty();
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Group item, string faculty)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();
                item.id_Faculty = Guid.Parse(faculty);
                await _repository.AddItemAsync(item);

                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _repository.GetItemAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.faculty = await _facultyRepository.ShowFacultyEdit(item);
            return View(item);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Group item, string faculty)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                item.id_Faculty = Guid.Parse(faculty);

                if (!await _repository.UpdateItem(item))
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _repository.GetItemAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}