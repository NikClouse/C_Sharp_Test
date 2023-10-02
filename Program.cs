using System;
using System.Collections.Generic;
using System.Linq;

namespace Meridiana
{
	public class Program
	{
		static void Main(string[] args)
		{

			var teachers = new List<Teacher> // Заполнить из файла Учетиля.txt
			{
				new Teacher { Name = "Марина ", LastName = "Петрова", Age = 41,Lesson = LessonType.Physic },
				new Teacher { Name = "Светлана ", LastName = "Иванова", Age = 45,Lesson = LessonType.Mathematic },
				new Teacher { Name = "Надежда ", LastName = "Карпова", Age = 39,Lesson = LessonType.Physic }
			};


			var students = new List<Student> // Заполнить из файла Ученики.txt

			 {
				new Student { Name = "Петя ", LastName = "Иванов", Age = 14 },
				new Student { Name = "Марина ", LastName = "Иванова", Age = 14 },
				new Student { Name = "Влад ", LastName = "Иванов", Age = 14 }
			 };


			var exams = new List<Exams>
			{

				new Exams { Lesson = LessonType.Physic, StudentName = "Петя",TeacherName  = "Марина", Score = 80, ExamDate = new DateTime(2023, 5, 10) },
				new Exams { Lesson = LessonType.Physic, StudentName = "Марина", TeacherName = "Светлана", Score = 95, ExamDate = new DateTime(2023, 5, 11) },
				new Exams { Lesson = LessonType.Physic, StudentName = "Влад", TeacherName = "Надежда", Score = 70, ExamDate = new DateTime(2023, 5, 12) },
				new Exams { Lesson = LessonType.Mathematic, StudentName = "Петя", TeacherName = "Марина", Score = 80, ExamDate = new DateTime(2023, 5, 10) },
				new Exams { Lesson = LessonType.Mathematic, StudentName = "Марина", TeacherName = "Светлана", Score = 93, ExamDate = new DateTime(2023, 5, 11) },
				new Exams { Lesson = LessonType.Mathematic, StudentName = "Влад", TeacherName = "Надежда", Score = 75, ExamDate = new DateTime(2023, 5, 12) },

			};

			//1. Найти учителя у которого в классе меньше всего учеников 

			var teacherWithFewestStudents = teachers
			   .OrderBy(t => students.Count(s => s.ID == t.ID))
			   .FirstOrDefault();
			Console.WriteLine($"Учитель с меньшим количеством учеников: {teacherWithFewestStudents.Name} {teacherWithFewestStudents.LastName}");
			Console.WriteLine();

			//2. Найти средний бал экзамена по Физики за 2023 год.			
			var averagePhysicsScore = exams
	.Where(e => e.Lesson == LessonType.Physic && e.ExamDate.Year == 2023)
	.Average(e => e.Score);

			// Форматирование вывода с одной цифрой после точки
			Console.WriteLine($"Средний балл по экзамену по Физике за 2023 год: {averagePhysicsScore:F1}");

			Console.WriteLine();

			//3.Получить количество учиников которые по экзамену Математики получили больше 90 баллов, где учитель Alex


			Console.WriteLine("учиников которые по экзамену Математики получили больше 90 баллов, где учительница Светлана ");
			var count = exams.Count(e => e.Lesson == LessonType.Mathematic && e.Score > 90 && e.TeacherName == "Светлана");
			Console.WriteLine($"Количество учеников: {count}  ");

		}
	}

	public class Person
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
	}

	public class Teacher : Person
	{
		public LessonType Lesson { get; set; }
	}

	public class Student : Person
	{

	}
	public class Exams
	{
		public LessonType Lesson { get; set; }

		public string StudentName { get; set; }
		public string TeacherName { get; set; }

		public decimal Score { get; set; }
		public DateTime ExamDate { get; set; }

		public Student Student { get; set; }
		public Teacher Teacher { get; set; }
	}

	public enum LessonType
	{
		Mathematic,
		Physic
	}
}
