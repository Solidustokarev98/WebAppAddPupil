using System.ComponentModel.DataAnnotations;

namespace WebAppAddPupil.Models
{
	public class Student
	{
		[Required(ErrorMessage = "Имя обязательно к заполнению.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Фамилия обязательно к заполнению.")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Возраст обязателен к заполнению.")]
		[Range(1, 100, ErrorMessage = "Возраст должен быть между 1 и 100.")]
		public int Age { get; set; }

		public string Class { get; set; }
	}
}
