using System.Xml.Serialization;

namespace ConsoleApp1;

public class Task48
{
    public static int CountOppositePairs(string filePath)
    {
        List<int> numbers = new List<int>();

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position <= reader.BaseStream.Length - sizeof(int))
            {
                numbers.Add(reader.ReadInt32());
            }
        }

        Console.WriteLine(string.Join(", ", numbers));

        int count = 0;
        HashSet<int> seenNumbers = new HashSet<int>();

        foreach (int number in numbers)
        {
            if (seenNumbers.Contains(-number))
            {
                count++;
                seenNumbers.Remove(-number);
            }
            else
            {
                seenNumbers.Add(number);
            }
        }

        return count;
    }

    public static void WriteRandomNumbers(string filePath, int count)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                writer.Write(random.Next(-100, 100));
                // writer.Write(random.Next(int.MinValue, int.MaxValue));
            }
        }
        Console.WriteLine("Файл успешно записан.");
    }

    public static void WriteRandomNumbersToFile(string filePath, int count)
    {
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(random.Next(-100, 100));
            }
        }
        Console.WriteLine("Файл успешно записан.");
    }

    public static void WriteRandomNumbersToFile(string filePath, int rowCount, int maxNumbersPerRow)
    {
        Random random = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < rowCount; i++)
            {
                int numbersPerRow = random.Next(1, maxNumbersPerRow + 1);
                List<int> numbers = new List<int>();
                for (int j = 0; j < numbersPerRow; j++)
                {
                    numbers.Add(random.Next(-100, 100));
                }
                writer.WriteLine(string.Join(" ", numbers));
            }
        }
        Console.WriteLine("Файл успешно записан.");
    }

    public static void WriteBaggageData(string filePath, List<Baggage> baggageList)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Baggage>));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, baggageList);
        }
    }

    public static double CalculateBaggageWeightDifference(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Baggage>));
        List<Baggage> baggageList;
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            baggageList = (List<Baggage>)serializer.Deserialize(fs);
        }

        if (baggageList == null || baggageList.Count == 0)
            throw new InvalidOperationException("No baggage data found.");

        double maxWeight = baggageList.Max(b => b.Weight);
        double minWeight = baggageList.Min(b => b.Weight);

        return maxWeight - minWeight;
    }

    public static bool FileContainsZero(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (int.Parse(line) == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static int FindMaxInFile(string filePath)
    {
        int max = int.MinValue;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
                int lineMax = numbers.Max();
                if (lineMax > max)
                {
                    max = lineMax;
                }
            }
        }
        return max;
    }

    public static void CopyLinesEndingWithChar(string inputFilePath, string outputFilePath, char endingChar)
    {
        using (StreamReader reader = new StreamReader(inputFilePath))
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.EndsWith(endingChar))
                {
                    writer.WriteLine(line);
                }
            }
        }
        Console.WriteLine("Файл успешно записан.");
    }
}
