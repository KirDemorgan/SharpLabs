namespace lab4;

public class Tasks
{
    public static void FirstTask(List<int> list, int e)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] == e && list[i + 1] != e)
            {
                list.RemoveAt(i + 1);
            }
        }
    }

    public static bool SecondTask(LinkedList<int> list)
    {
        if (list.Count == 0 || list.Count == 1)
        {
            return false;
        }

        if (list.First!.Value == list.Last!.Value)
        {
            return true;
        }

        var currentNode = list.First;
        while (currentNode.Next != null)
        {
            if (currentNode.Value == currentNode.Next.Value)
                return true;
            currentNode = currentNode.Next;
        }

        return false;
    }

    public static void ThirdTask(List<HashSet<string>> touristsData, HashSet<string> countries)
    {
        var all = new HashSet<string>(countries);
        var some = new HashSet<string>();
        var none = new HashSet<string>(countries);

        foreach (var tour in touristsData)
        {
            all.IntersectWith(tour); // all = all ∩ tour | возвращает общие элементы
            some.UnionWith(tour); // some = some ∪ tour | возвращает все элементы, объединяет два сета
            none.ExceptWith(tour); // none = none \ tour | возвращает элементы, которые есть в первом сете, но нет во втором
        }
        Console.WriteLine("Страны, которые посетили все туристы:");
        foreach (var country in all)
        {
            Console.WriteLine(country);
        }

        Console.WriteLine("\nСтраны, которые посетили некоторые туристы:");
        foreach (var country in some)
        {
            Console.WriteLine(country);
        }

        Console.WriteLine("\nСтраны, которые не посетили туристы:");
        foreach (var country in none)
        {
            Console.WriteLine(country);
        }
    }

    public static void FourthTask(string filePath)
    {
        HashSet<char> voicelessConsonants = ['п', 'ф', 'к', 'т', 'ш', 'с', 'ч', 'ц'];

        try
        {
            var text = File.ReadAllText(filePath);

            var words = text.Split(new char[] { ' ', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '—' },
                StringSplitOptions.RemoveEmptyEntries);
            
            var count = new Dictionary<char, int>();

            foreach (var word in words)
            {
                var uniqueChars = new HashSet<char>(word);
                foreach (var chr in uniqueChars)
                {
                    if (voicelessConsonants.Contains(chr))
                    {
                        count[chr] = count.ContainsKey(chr) ? count[chr] + 1 : 1;
                    }
                }
            }

            var result = count.Where(k => k.Value != 1).Select(k => k.Key).ToList();
            result.Sort();

            Console.WriteLine("Согласные глухие буквы, которые встречаются в словах более одного раза:");
            foreach (var chr in result)
            {
                Console.Write(chr + " ");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Не удалось прочитать файл: " + e.Message);
            throw;
        }
    }



}