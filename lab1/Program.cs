namespace lab1;

class Program
{
    private static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("Lab 1 variant 2");
        Console.WriteLine("Tasks in tasks 2 4 6 8 10\n");
        Console.WriteLine("Enter a task number: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
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
                Console.WriteLine("\nEnter 2 numbers to test task 2: ");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.safeDiv(x, y));

                Console.WriteLine("\nEnter 2 numbers to test task 4: ");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.makeDecision(x, y));

                Console.WriteLine("\nEnter 3 numbers to test task 6: ");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.sum3(x, y, c));

                Console.WriteLine("\nEnter a number to test task 8: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.age(x));

                Console.WriteLine("\nEnter a day of the week to test task 10: ");
                string day = Console.ReadLine();
                p.printDays(day);
                break;
            case 3:
                Console.WriteLine("\nEnter a number to test task 2: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.reverseListNums(x));

                Console.WriteLine("\nEnter 2 numbers to test task 4: ");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.pow(x, y));

                Console.WriteLine("\nEnter a number to test task 6: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.equalNum(x));

                Console.WriteLine("\nEnter a number to test task 8: ");
                x = Convert.ToInt32(Console.ReadLine());
                p.leftTriangle(x);

                Console.WriteLine("\nGuess the number from 0 to 9: ");
                p.guessGame();
                break;
            case 4:
                Console.WriteLine("\nEnter an array of numbers to test task 2: ");
                int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine("\nEnter a number to find in the array: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(p.findLast(arr, x));

                Console.WriteLine("\nEnter an array of numbers to test task 4: ");
                arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Console.WriteLine("\nEnter a number to add: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter a position to add the number: ");
                y = Convert.ToInt32(Console.ReadLine());
                int[] result = p.add(arr, x, y);
                Console.WriteLine(string.Join(" ", result));

                Console.WriteLine("\nEnter an array of numbers to test task 6: ");
                arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                p.reverse(arr);

                Console.WriteLine("\nEnter 2 arrays of numbers to test task 8: ");
                int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                result = p.concat(arr1, arr2);
                Console.WriteLine(string.Join(" ", result));

                Console.WriteLine("\nEnter an array of numbers to test task 10: ");
                arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                result = p.deleteNegative(arr);
                Console.WriteLine(string.Join(" ", result));
                break;
            default:
                Console.WriteLine("Invalid task number");
                break;
        }
    }


    /*========================================================================
     Задание 1. Методы
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
        int sum = (a%10) + (b%10);

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter a "+ (i + 1) + " number: ");
             b = Convert.ToInt32(Console.ReadLine());
            sum = (sum % 10) + (b % 10);
        }
        return sum;
    }

    /*========================================================================
     Задание 2. Условия
    ========================================================================*/
    // 2.2
    public double safeDiv(int x, int y)
    {
        if (y == 0)
        {
            return 0;
        }
        return (double)x / y;
    }

    // 2.4
    public String makeDecision(int x, int y)
    {
        if (x > y) return $"{x} > {y}";
        if (x < y) return $"{x} < {y}";
        return $"{x} == {y}";
    }

    // 2.6
    public bool sum3(int x, int y, int z)
    {
        return (x + y == z) || (x + z == y) || (y + z == x);
    }

    // 2.8
    public String age(int x)
    {
        if ((x % 10 == 1) && x != 11) return $"{x} год";
        if (x % 10 >= 2 && x % 10 <= 4 && x != 12 && x != 13 && x != 14) return $"{x} года";
        return $"{x} лет";
    }

    // 2.10
    public void printDays(string x)
    {
        switch (x.ToLower())
        {
            case "понедельник":
                Console.WriteLine("понедельник");
                goto case "вторник";
            case "вторник":
                Console.WriteLine("вторник");
                goto case "среда";
            case "среда":
                Console.WriteLine("среда");
                goto case "четверг";
            case "четверг":
                Console.WriteLine("четверг");
                goto case "пятница";
            case "пятница":
                Console.WriteLine("пятница");
                goto case "суббота";
            case "суббота":
                Console.WriteLine("суббота");
                goto case "воскресенье";
            case "воскресенье":
                Console.WriteLine("воскресенье");
                break;
            default:
                Console.WriteLine("это не день недели");
                break;
        }
    }

    /*========================================================================
    Задание 3. Циклы
    ========================================================================*/
        // 3.2
        public String reverseListNums(int x)
        {
            string result = x.ToString();
            while (x > 0)
            {
                result += x - 1;
                x--;
            }
            return result;
        }

        // 3.4
        public int pow(int x, int y)
        {
            int result = 1;
            for (int j = 0; j < y; j++)
            {
                result *= x;
            }
            return result;
        }

        // 3.6
        public bool equalNum(int x)
        {
            int lastDigit = x % 10;
            while (x > 0)
            {
                if (x % 10 != lastDigit)
                {
                    return false;
                }
                x /= 10;
            }
            return true;
        }

        // 3.8
        public void leftTriangle(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        // 3.10
        public void guessGame()
        {
            Random rnd = new Random();

            bool isGameOver = false;
            int generatedNumber = rnd.Next(0, 10);
            int attempts = 0;

            while (!isGameOver)
            {
                int userNumber = Convert.ToInt32(Console.ReadLine());
                attempts++;
                if (userNumber == generatedNumber)
                {
                    Console.WriteLine("Вы угадали!");
                    Console.WriteLine($"Вы отгадали число за {attempts} попытки");
                    isGameOver = true;
                }
                else
                {
                    Console.WriteLine("Вы не угадали, введите число от 0 до 9:");
                }
            }
        }

        /*========================================================================
        Задание 4. Массивы
        ========================================================================*/
        // 4.2
        public int findLast(int[] arr, int x)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        // 4.4
        public int[] add(int[] arr, int x, int pos)
        {
            int[] newArr = new int[arr.Length + 1];
            for (int i = 0, j = 0; i < newArr.Length; i++)
            {
                if (i == pos)
                {
                    newArr[i] = x;
                }
                else
                {
                    newArr[i] = arr[j];
                    j++;
                }
            }
            return newArr;
        }

        // 4.6
        public void reverse (int[] arr) {
            int[] reversedArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                reversedArr[i] = arr[arr.Length - 1 - i];
            }
            Console.WriteLine(string.Join(" ", reversedArr));
        }

        // 4.8
        public int[] concat(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result[arr1.Length + i] = arr2[i];
            }
            return result;
        }

        // 4.10
        public int[] deleteNegative(int[] arr)
        {
            int positiveCount = 0;
            foreach (int num in arr)
            {
                if (num > 0)
                {
                    positiveCount++;
                }
            }

            int[] result = new int[positiveCount];
            int index = 0;

            foreach (int num in arr)
            {
                if (num >= 0)
                {
                    result[index++] = num;
                }
            }

            return result;
        }
}