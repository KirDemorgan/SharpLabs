using System.Text;
using System.Xml.Serialization;

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

            // var result = count.Where(k => k.Value != 1).Select(k => k.Key).ToList();
            var result = count.Where(k => k.Value == words.Length - 1).Select(k => k.Key).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Согласные глухие буквы, которые не встречаются в одном слове: отсутствуют");
                return;
            }

            result.Sort();

            Console.WriteLine("Согласные глухие буквы, которые не встречаются в одном слове:");
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

    private static void FifthTaskFileCreate(string filePath, List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)> applicants)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)>));
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            serializer.Serialize(writer, applicants);
        }
    }

    private static List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)> FifthTaskFileRead(
        string filePath)
    {
        XmlSerializer serializer =
            new XmlSerializer(typeof(List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)>)serializer
                .Deserialize(reader) ?? throw new InvalidOperationException("Файл пуст");
        }
    }

    private static void ValidateData(string lastName, string firstName, int subject1Score, int subject2Score)
    {
        if (lastName.Length == 0 || firstName.Length == 0)
        {
            throw new Exception("Фамилия и имя не могут быть пустыми.");
        }

        if (subject1Score < 0 || subject1Score > 100 || subject2Score < 0 || subject2Score > 100)
        {
            throw new Exception("Оценки должны быть в диапазоне от 0 до 100.");
        }

        if (lastName.Length > 20)
        {
            throw new Exception("Фамилия не может быть длиннее 20 символов.");
        }

        if (firstName.Length > 15)
        {
            throw new Exception("Имя не может быть длиннее 15 символов.");
        }
    }

    public static void ReadApplicantsFromInput(string filePath)
    {
        try
        {
            Console.Write("Введите количество абитуриентов: ");
            int n = int.Parse(Console.ReadLine());
            if (n > 500)
            {
                throw new Exception("Количество абитуриентов не может превышать 500.");
            }

            var applicants = new List<(string LastName, string FirstName, int Subject1Score, int Subject2Score)>();
            Console.WriteLine("Введите данные абитуриентов в формате: Фамилия Имя Оценка1 Оценка2");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите данные абитуриента {i + 1}: ");
                string[] input = Console.ReadLine().Split(' ');
                string lastName = input[0];
                string firstName = input[1];
                int subject1Score = int.Parse(input[2]);
                int subject2Score = int.Parse(input[3]);

                ValidateData(lastName, firstName, subject1Score, subject2Score);

                applicants.Add((lastName, firstName, subject1Score, subject2Score));
            }
            FifthTaskFileCreate(filePath, applicants);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static void FifthTask(string filePath)
    {
        try
        {
            var applicants = FifthTaskFileRead(filePath);

            var failedApplicants = new SortedList<string, string>();

            foreach (var applicant in applicants)
            {
                if (applicant.Subject1Score < 30 && applicant.Subject2Score < 30)
                {
                    string key = applicant.LastName + " " + applicant.FirstName;
                    int counter = 1;
                    while (failedApplicants.ContainsKey(key))
                    {
                        key = applicant.LastName + " " + applicant.FirstName + " " + counter;
                        counter++;
                    }
                    failedApplicants.Add(key, applicant.LastName + " " + applicant.FirstName);
                }
            }

            if (failedApplicants.Count == 0)
            {
                Console.WriteLine("Все абитуриенты допущены к сдаче экзаменов в первом потоке.");
                return;
            }

            Console.WriteLine("Абитуриенты, не допущенные к сдаче экзаменов в первом потоке:");
            foreach (var applicant in failedApplicants.Values)
            {
                Console.WriteLine(applicant);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}