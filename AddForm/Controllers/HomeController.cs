using AddForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddForm.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        List<Student> students = new List<Student>();

        public ActionResult Index()
        {
            var std = new Student();
            std.Name = "ali";
            std.Age = 22;

            students.Add(std);

            return View(students);
        }

        
        public ActionResult AddObject() {
            ViewModelStudent student = new ViewModelStudent();
            return View(student);
        }


        [HttpPost]
        public ActionResult AddObject(ViewModelStudent student) 
        {
            if (ModelState.IsValid)
            {
                Student tst = new Student
                {
                    Name = student.Name,
                    Age = student.Fail ? 1 : 0
                };
                students.Add(tst);
                return View("Index",students);
            }

            
            return RedirectToAction("Index", "Home");

        }

    }
}
