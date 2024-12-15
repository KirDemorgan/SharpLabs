using System.Collections;

namespace lab6;

class Program
{
    static void Main(string[] args)
    {
        // Задание 1
        // 1 задача
        try
        {
            var cat = new Cat("Барсик");
            cat.Meow();
            cat.Meow(3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine();
            Console.WriteLine();
            // 2 задача
            List<IMeowable> meowables = new List<IMeowable>();
            meowables.Add(new Cat("Барсик"));
            meowables.Add(new Cat("Широ"));
            meowables.Add(new Cat("Балбес"));

            meowables.Add(new Tiger("Мурзик"));
            meowables.Add(new Tiger("Маркиз"));

            MeowAll(meowables);

            Console.WriteLine();
            Console.WriteLine();
            // 3 задача

            List<IMeowable> meowables2 = new List<IMeowable>();
            meowables2.Add(new MeowCounter(new Cat("Барсик")));
            meowables2.Add(new MeowCounter(new Cat("Широ")));
            meowables2.Add(new MeowCounter(new Cat("Балбес")));

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            MeowAll(meowables2);

            foreach (var meowable in meowables2)
            {
                var meowCounter = (MeowCounter)meowable;
                var cat = (Cat)meowCounter.Meowable;
                Console.WriteLine($"{cat.Name} мяукал: {meowCounter.GetMeowCount()} раз");
            }

            Console.WriteLine();
            var senya = new MeowCounter(new Cat("Сеня"));
            senya.Meow(5);
            Console.WriteLine($"{senya.Meowable} мяукал: {senya.GetMeowCount()} раз");
            senya.Meow();
            Console.WriteLine($"{senya.Meowable} мяукал: {senya.GetMeowCount()} раз");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void MeowAll(IEnumerable<IMeowable> meowables)
    {
        foreach (var meowable in meowables)
        {
            meowable.Meow();
        }
    }
}