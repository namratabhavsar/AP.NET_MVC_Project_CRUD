using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Data;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext DbContext;
        public StudentsController(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

       

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student stViewModel)
        {
            var student = new Student();
            student.Id = new Guid();
            student.Name = stViewModel.Name;
            student.Email = stViewModel.Email;
            student.Phone = stViewModel.Phone;
            student.Subscribed = stViewModel.Subscribed;
            await DbContext.AddAsync(student);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var students = await DbContext.Students.ToListAsync();

            return View(students);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var students =  await DbContext.Students.FindAsync(id);

            return View(students);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student stViewModel)
        {
            var student = await DbContext.Students.FindAsync(stViewModel.Id);
            if(student is not null)
            {
                student.Name = stViewModel.Name;
                student.Email = stViewModel.Email;
                student.Phone = stViewModel.Phone;
                student.Subscribed = stViewModel.Subscribed;

                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("List","Students");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await DbContext.Students.FindAsync(id);
            if(student is not null)
            {
                DbContext.Students.Remove(student);
                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
