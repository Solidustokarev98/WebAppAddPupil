using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebAppAddPupil.Models;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private const string FilePath = "students.json";

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                var students = new List<Student>();

                // Если файл уже существует, считываем существующих учеников
                if (System.IO.File.Exists(FilePath))
                {
                    var json = System.IO.File.ReadAllText(FilePath);
                    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }

                students.Add(student);

                // Сохраняем текущих учеников обратно в файл
                var jsonStudents = JsonSerializer.Serialize(students);
                System.IO.File.WriteAllText(FilePath, jsonStudents);

                return RedirectToAction("Success");
            }
            return View(student);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult List()
        {
            var students = new List<Student>();

            if (System.IO.File.Exists(FilePath))
            {
                var json = System.IO.File.ReadAllText(FilePath);
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }

            return View(students);
        }
    }
}
