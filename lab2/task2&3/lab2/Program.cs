using System.Text;

namespace lab2;
// Задания 2 и 3 решаются в одном проекте (задание 3 продолжает задание 2).
// В задании 2 необходимо реализовать определение класса (поля, свойства, конструкторы, перегрузка
// метода ToString() для вывода полей, заданный метод согласно варианту). Протестировать все
// методы, включая конструкторы (при тестировании методов классов в заданиях не забывайте
// проверять вводимые пользователем данные на корректность).
// В задании 3 добавить к реализованному в задании 2 классу указанные в варианте перегруженные
// операции. Протестировать все методы.
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            Console.WriteLine("Введите катет a:");
            double a = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            while (a <= 0) {
                Console.WriteLine("Введено неверное значение, попробуйте еще раз");
                Console.WriteLine("Введите катет a:");
                a = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Введите катет b:");
            double b = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            while (b <= 0) {
                Console.WriteLine("Введено неверное значение, попробуйте еще раз");
                Console.WriteLine("Введите катет b:");
                b = double.Parse(Console.ReadLine());
            }

            RightTriangle triangle = new RightTriangle(a, b);
            Console.WriteLine($"\nПлощадь введенного треугольника:  {triangle.CalculateArea()}");
            Console.WriteLine(triangle.ToString());
            Console.WriteLine("\nУвеличиваем стороны в 2 раза");
            RightTriangle newTriangle = triangle++;
            Console.WriteLine($"Площадь нового треугольника:  {newTriangle.CalculateArea()}");
            Console.WriteLine(newTriangle.ToString());

            Console.WriteLine("\nУменьшаем стороны в 2 раза");
            RightTriangle newTriangle2 = newTriangle--;
            Console.WriteLine($"Площадь нового треугольника:  {newTriangle2.CalculateArea()}");
            Console.WriteLine(newTriangle2.ToString());

            Console.WriteLine("\nПриводим к типу double");
            Console.WriteLine((double)newTriangle2);

            Console.WriteLine("\nПриводим к типу bool");
            Console.WriteLine(newTriangle2);

            RightTriangle newTriangle3 = new RightTriangle(3, 4);
            RightTriangle newTriangle4 = new RightTriangle(4, 5);
            Console.WriteLine($"Сравниваем площадь треугольников: {newTriangle3.CalculateArea()} и {newTriangle4.CalculateArea()}");
            Console.WriteLine("<=");
            Console.WriteLine(newTriangle3 <= newTriangle4);
            Console.WriteLine("=>");
            Console.WriteLine(newTriangle3 >= newTriangle4);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Введены неверные данные, попробуйте еще раз");
        }
    }
}