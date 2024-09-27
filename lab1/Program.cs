namespace lab1;

class Program
{
    private static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("Lab 1 variant 2");
        Console.WriteLine("Enter a task number: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Tasks 2 4 6 8 10");
                Console.WriteLine("\nEnter a number to test task 2: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sum of 2 last digits: "+ p.sumLastNums(x));


                Console.WriteLine("\nEnter a number to test task 4: ");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.isPositive(y));

                Console.WriteLine("\nEnter a character to test task 6: ");
                char z = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(p.isUpperCase(z));

                Console.WriteLine("\nEnter 2 numbers to test task 8: ");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.isDivisor(a, b));

                Console.WriteLine("\nEnter 2 numbers to test task 10: ");
                int c = Convert.ToInt32(Console.ReadLine());
                int d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.lastNumSum(c, d));
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Invalid task number");
                break;
        }
    }


    /*========================================================================
     ========================================================================*/
    // 1.2
    public int sumLastNums(int x)
    {
        if (x < 100)
        {
            Console.WriteLine("Number is less than 100");
            return -1;
        }

        int lastDigit = x % 10;
        int secondLastDigit = (x / 10) % 10;

        return lastDigit + secondLastDigit;
    }

    // 1.4
    public bool isPositive (int x)
    {
        return x > 0;
    }

    // 1.6
    public bool isUpperCase(char x)
    {
        return x >= 'A' && x <= 'Z';
    }

    // 1.8
    public bool isDivisor(int a, int b)
    {
        return a % b == 0 || b % a == 0;
    }

    public int lastNumSum(int a, int b)
    {
        int sum = a + (b%10);

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter a "+ (i + 1) + " number: ");
             b = Convert.ToInt32(Console.ReadLine());
            sum = (sum % 10) + (b % 10);
        }
        return sum;
    }

    /*========================================================================
 ========================================================================*/


}