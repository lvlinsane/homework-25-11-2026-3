using System;

namespace StudentApp
{
    struct Course
    {
        public int CourseId { get; }
        public string CourseName { get; }
        public int Credits { get; }
        public int Semester { get; }
        public CourseType Type { get; }

        public Course(int courseId, string courseName, int credits, int semester, CourseType type)
        {
            if (credits <= 0)
            {
                throw new ArgumentException("Количество кредитов должно быть больше нуля!");
            }

            if (semester < 1 || semester > 8)
            {
                throw new ArgumentException("Номер семестра должен быть от 1 до 8!");
            }

            if (!Enum.IsDefined(typeof(CourseType), type))
            {
                throw new ArgumentException("Неверный тип дисциплины!");
            }

            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;
            Semester = semester;
            Type = type;
        }

        public string GetTypeDescription()
        {
            switch (Type)
            {
                case CourseType.Mandatory:
                    return "Обязательная";
                case CourseType.Elective:
                    return "По выбору";
                case CourseType.Optional:
                    return "Факультативная";
                default:
                    return "Неизвестный тип";
            }
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Id дисциплины: " + CourseId);
            Console.WriteLine("Название: " + CourseName);
            Console.WriteLine("Кредиты: " + Credits);
            Console.WriteLine("Семестр: " + Semester);
            Console.WriteLine("Тип: " + GetTypeDescription());
            Console.WriteLine("-----------------------");
        }
    }
}
