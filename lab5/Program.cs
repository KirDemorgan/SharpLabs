namespace lab5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Создать новый файл или дописывать в существующий? ([N]ew / [A]ppend): ");
        string userInput = Console.ReadLine();
        bool append = userInput?.ToLower() == "a";
        var logger = new Logger("log.txt", append);


        var dbWorker = new DBWorker(logger);
        dbWorker.LoadDataFromExcel("LR5-var4.xls");
        dbWorker.PrintData();
    }
}