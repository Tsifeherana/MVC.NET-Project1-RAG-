using Microsoft.AspNetCore.Mvc;
using Projet1.Models;
using Microsoft.EntityFrameworkCore;
using Projet1.Data;

namespace Projet1.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyAppContext _context;
        public StudentController(MyAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("Mail","Name","NoInscription","Phone","Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Mail", "Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = await _context.Student.FirstOrDefaultAsync(
                    s => s.Mail == student.Mail && s.Password == student.Password
                );
                if(existingStudent != null ) return RedirectToAction("Index"); 
                else
                {
                    ModelState.AddModelError("" , " Mail ou Mot de passe Incorrect");
                }
            }
            return View(student);
        }
    }
}
