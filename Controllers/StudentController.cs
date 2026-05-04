using Microsoft.AspNetCore.Mvc;
using Projet1.Models;
using Projet1.ViewModels;
using Microsoft.EntityFrameworkCore;
using Projet1.Data;
using Microsoft.AspNetCore.Identity;

namespace Projet1.Controllers
{
    public class StudentController : Controller
    {
        private readonly PasswordHasher<Student> _hasher = new();
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

        // mot de passe a crypter
        // verification unicite
        // faire en string phone 
        // email de confirmation
        
                
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var EmailExiste = await _context.Student.AnyAsync(s => s.Mail == vm.Mail);
            if(EmailExiste)
            {
                ModelState.AddModelError("Mail", "Cet Mail est deja utilisee");
                return View(vm);
            }

            var student = new Student 
            {
                Mail = vm.Mail,
                Name = vm.Name,
                NoInscription = vm.NoInscription,
                Phone = vm.Phone
            };

            //hasher le mot de passe avant stockage 
            student.Password = _hasher.HashPassword(student, vm.Password);

            _context.student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Mail", "Password")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var existingStudent = await _context.Student.FirstOrDefaultAsync(
                s => s.Mail == student.Mail
            );

            if(existingStudent == null || string.IsNullOrEmpty(existingStudent.Password))
            {
                ModelState.AddModelError("", " Mail ou mot de passe incorrect");
                return View(student);
            }

            var result = _hasher.VerifyHashedPassword(
                existingStudent,
                existingStudent.Password,
                student.Password ?? string.Empty
            );
            if(result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Mail ou mot de passe incorrect");
                return View(student);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
