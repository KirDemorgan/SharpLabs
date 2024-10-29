using System.Text;
using Lab2;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                //Тесты класса Product
                // Тесты конструкторов Product
                Product product1 = new Product();
                product1.Id = 1;
                product1.Amount = 5;
                product1.Price = 50;

                Product product2 = new Product(2, 10, 100);
                Product product3 = new Product(product2);

                // Тесты методов Product
                Console.WriteLine("\nВывод всех объектов Product:");
                Console.WriteLine($"Product1: {product1}");
                Console.WriteLine($"Product2: {product2}");
                Console.WriteLine($"Product3: {product3}");
                Console.WriteLine("\nМинимальное значение у полей Product2:");
                int minForProduct2 = product2.MinField();

                // Тесты класса ElectronicProduct
                // Тесты конструкторов ElectronicProduct
                ElectronicProduct eProduct1 = new ElectronicProduct();
                eProduct1.Id = 1;
                eProduct1.Amount = 5;
                eProduct1.Price = 100;
                eProduct1.Name = "Smartphone";
                eProduct1.Manufacturer = "Samsung";
                eProduct1.PurchaseDate = new DateTime(2021, 1, 1);
                eProduct1.WarrantyPeriod = 12;

                ElectronicProduct eProduct2 = new ElectronicProduct(2, 5, 200, "Laptop", "Dell", new DateTime(2023, 1, 1), 24);

                Console.WriteLine("\nВывод всех объектов ElectronicProduct:");
                Console.WriteLine($"eProduct1: {eProduct1}");
                Console.WriteLine($"eProduct2: {eProduct2}");
                Console.WriteLine($"\nДата окончания гарантии для  eProduct2: {eProduct2.CalculateWarrantyEndDate().ToShortDateString()}");
                Console.WriteLine($"\nАктуальна ли гарантия для eProduct2? {eProduct2.IsUnderWarranty()}");
                Console.WriteLine($"\nГарантия у eProduct2 до {eProduct2.WarrantyPeriod}. Продлим гарантию для eProduct2 на 12 месяцев");
                eProduct2.ExtendWarranty(12);
                Console.WriteLine($"Продленный срок гарантии для eProduct2: {eProduct2.WarrantyPeriod} месяцев");
                Console.WriteLine(eProduct2.MinField());

                // Бросаем крутое исключение и финал
                Console.WriteLine("\nТестирование исключений:");
                ElectronicProduct eProduct3 = new ElectronicProduct(3, 10, -300, "Tablet", "Apple", new DateTime(2022, 1, 1), 36);
                ElectronicProduct eProduct4 = new ElectronicProduct(3, 10, -300, "Tablet", "Apple", new DateTime(2022, 1, 1), 36);


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Получено и обработано исключение неправильного аргумента: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Получено и обработано исключение: {ex.Message}");
            }
        }
    }
}