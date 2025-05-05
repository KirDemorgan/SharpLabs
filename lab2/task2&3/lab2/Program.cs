using System.Text;

namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        double a = GetPositiveDouble("Введите катет a:");
        double b = GetPositiveDouble("Введите катет b:");

        try
        {
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

    static double GetPositiveDouble(string prompt)
    {
        double value;
        while (true)
        {
            try
            {
                Console.WriteLine(prompt);
                value = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                if (value > 0) break;
                Console.WriteLine("Значение должно быть больше 0. Попробуйте снова.");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода. Попробуйте снова.");
            }
        }
        return value;
    }
}
