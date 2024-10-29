namespace ConsoleApp1;

public class Task123
{
    private double[,] _array;
    
    public double this[int row, int col]
    {
        get => _array[row, col];
        set => _array[row, col] = value;
    }

    // Task 1
    public Task123(int n, int m)
    {
        _array = new double[n, m];
        FillArrayFromKeyboard();
    }

    public Task123(double[,] array)
    {
        _array = array;
    }

    // Task 2
    public Task123(int n)
    {
        _array = new double[n, n];
        FillArrayWithRandomNumbers();
    }

    public Task123(int n, string s)
    {
        _array = new double[n, n];
        FillTask123();
    }


    private void FillArrayFromKeyboard()
    {
        for (var i = 0; i < _array.GetLength(0); i++)
        {
            for (var j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"Введите элемент для [{i+1},{j+1}]: ");
                _array[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    private void FillArrayWithRandomNumbers()
    {
        var random = new Random();
        int n = _array.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j > n - i - 1) // Элементы выше побочной диагонали
                {
                    _array[i, j] = random.Next(-65, 120); // Интервал [-65, 120]
                }
                else // Элементы на побочной диагонали и ниже
                {
                    _array[i, j] = random.NextDouble() * (10.75 - (-3.5)) + (-3.5); // Интервал [-3.5, 10.75]
                }
            }
        }
    }


    // Метод для заполнения массива по диагоналям
    private void FillTask123()
    {
        var n = _array.GetLength(0);
                 int k = 0, l = n - 1, count = 1;
                 var direction = true;

                 while (count < n * (n + 1) / 2)
                 {
                     if (direction)
                     {
                         while (l <= n - 1)
                         {
                             _array[k, l] = count;
                             l++;
                             k++;
                             count++;
                         }

                         l--;
                         direction = false;
                     }
                     else
                     {
                         while (k >= 0)
                         {
                             _array[k, l] = count;
                             l--;
                             k--;
                             count++;
                         }

                         k++;
                         direction = true;
                     }
                 }

    }

    public int GetBankWithMaxDebt()
    {
        int bankCount = _array.GetLength(0);
        double maxDebt = double.MinValue;
        int bankWithMaxDebt = -1;

        for (int i = 0; i < bankCount; i++)
        {
            double totalDebt = 0;
            for (int j = 0; j < bankCount; j++)
            {
                totalDebt += _array[i, j];
            }

            if (totalDebt > maxDebt)
            {
                maxDebt = totalDebt;
                bankWithMaxDebt = i;
            }
        }

        return bankWithMaxDebt;
    }


    public static Task123 operator -(Task123 a, Task123 b)
    {
        int aRows = a._array.GetLength(0);
        int aColumns = a._array.GetLength(1);
        int bRows = b._array.GetLength(0);
        int bColumns = b._array.GetLength(1);
        
        if (aRows != bRows || aColumns != bColumns)
            throw new ArgumentException("Task123 dimensions must match for subtraction.");

        double[,] result = new double[aColumns, aRows];
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return new Task123(result);
    }

    public static Task123 operator *(Task123 a, Task123 b)
    {
        int aRows = a._array.GetLength(0);
        int aColumns = a._array.GetLength(1);
        int bRows = b._array.GetLength(0);
        int bColumns = b._array.GetLength(1);
        
        if (aColumns != bRows)
            throw new ArgumentException("Task123 dimensions must match for multiplication.");

        double[,] result = new double[aColumns, aRows];
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < bColumns; j++)
            {
                for (int k = 0; k < aColumns; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return new Task123(result);
    }

    public static Task123 operator *(int scalar, Task123 a)
    {
        int aRows = a._array.GetLength(0);
        int aColumns = a._array.GetLength(1);
        
        double[,] result = new double[aColumns, aRows];
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }
        return new Task123(result);
    }

    public Task123 Transpose()
    {
        int aRows = _array.GetLength(0);
        int aColumns = _array.GetLength(1);

        double[,] result = new double[aColumns, aRows];
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                result[j, i] = _array[i, j];
            }
        }

        return new Task123(result);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            Enumerable.Range(0, _array.GetUpperBound(0) + 1)
                .Select(i => "{" + string.Join("\t", Enumerable.Range(0, _array.GetUpperBound(1) + 1)
                .Select(j => _array[i, j].ToString("F2"))) + "}"));
    }
}