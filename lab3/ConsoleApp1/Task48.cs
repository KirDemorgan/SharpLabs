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
}