using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание элементов класса
            Man man = new Man("Артём", 18);
            Student student = new Student("1-й МОК", 3);
            Worker worker = new Worker("СЕТ-1");

            // Создание листа
            List<Man> men = new List<Man>() { man, student, worker};
            
            // Вывод информации
            man.Show();
            student.Show();
            worker.Show();
        }

        // Базовый класс
        class Man
        {
            // Поля
            private string _name;
            private byte _age;

            // Свойства
            public string name
            {
                get { return _name; }
                set { _name = value; }
            }

            public byte age
            {
                get { return _age; }
                set { if (value > 0) _age = value; }
            }

            // Конструкторы
            public Man() { }
            public Man(string a, byte b)
            {
                name = a;
                age = b;
            }

            // Метод вывода
            public void Show()
            {
                Console.WriteLine($"Имя: {name}\nВозраст: {age}");
            }
        }

        class Student : Man
        {
            // Поля
            private string _college;
            private byte _course;

            // Свойства
            public string college
            {
                get { return _college; }
                set { _college = value; }
            }
            public byte course
            {
                get { return _course; }
                set { if (value > 0 && value < 7) _course = value; }
            }

            // Конструкторы
            public Student() { }
            public Student(string a, byte b)
            {
                _college = a;
                _course = b;
            }

            // Метод вывода
            public void Show()
            {
                Console.WriteLine($"Колледж: {college}\nКурс: {course}");
            }
        }

        class Worker : Man
        {
            // Поля
            private string _workPlace;

            // Свойства
            public string workPlace
            {
                get { return _workPlace; }
                set { _workPlace = value; }
            }

            // Конструкторы
            public Worker() { }
            public Worker(string a)
            {
                _workPlace = a;
            }

            // Метод вывода
            public void Show()
            {
                Console.WriteLine($"Место работы: {workPlace}");
            }
        }
    }
}
