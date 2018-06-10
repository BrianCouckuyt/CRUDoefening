using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDoefening.web.Models;
using CRUDoefening.web.Data;
using CRUDoefening.web.Entities;
using Microsoft.EntityFrameworkCore;
using CRUDoefening.web.ViewModels;

namespace CRUDoefening.web.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext _schoolContext;
        public HomeController(SchoolContext context)
        {
            _schoolContext = context;

            _schoolContext.Set<Teacher>()
                          .Include(t => t.Students)
                          .ThenInclude(s => s.ContactInfo)
                          .Include(t => t.Courses)
                          .ToList();
        }


        public IActionResult Index()
        {
            var vm = new HomeIndexVm();
            vm.Teachers = _schoolContext.Teachers;
            return View(vm);
        }

        public async Task<IActionResult> StudentDetails(long id)
        {
            Student student = await _schoolContext.Students.FindAsync(id);

            if (student != null)
                return View(student);
            else
                return NotFound($"Student not found.");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            Student StudentToDelete = await _schoolContext.Students.FindAsync(student.Id);

            if (student != null)
            {
                _schoolContext.Remove(StudentToDelete);
                await _schoolContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return NotFound("student not found");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(Student student)
        {

            if (student != null)
            {
                _schoolContext.Students.Update(student);
                _schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return NotFound("student not found");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
