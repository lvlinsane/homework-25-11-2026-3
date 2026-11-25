using System;

namespace StudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(1, "Иванов Иван Иванович", 18, "ИС-11", 85.5, StudyStatus.Active, EducationLevel.Bachelor);
            student.DisplayInfo();

            Console.WriteLine("Выберите новый статус студента:");
            Console.WriteLine("0 - Active");
            Console.WriteLine("1 - AcademicLeave");
            Console.WriteLine("2 - Graduated");
            Console.WriteLine("3 - Expelled");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number) && Enum.IsDefined(typeof(StudyStatus), number))
            {
                student.SetStatus((StudyStatus)number);
                Console.WriteLine("Статус изменён!");
                Console.WriteLine();
                student.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Ошибка: введено неверное значение!");
            }

            Console.WriteLine("===== Учебные дисциплины =====");

            Course[] courses = new Course[]
            {
                new Course(1, "Программирование на C#", 6, 1, CourseType.Mandatory),
                new Course(2, "Высшая математика", 5, 1, CourseType.Mandatory),
                new Course(3, "Базы данных", 4, 2, CourseType.Mandatory),
                new Course(4, "Веб-дизайн", 3, 3, CourseType.Elective),
                new Course(5, "Английский для IT", 2, 4, CourseType.Optional)
            };

            foreach (Course course in courses)
            {
                course.DisplayCourseInfo();
            }

            try
            {
                Course bad1 = new Course(6, "Физика", 0, 2, CourseType.Mandatory);
                bad1.DisplayCourseInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            try
            {
                Course bad2 = new Course(7, "История", 3, 9, CourseType.Elective);
                bad2.DisplayCourseInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
