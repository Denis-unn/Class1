using System;

class Class1
{
    static void Main()
    {
        Console.Write("Введите количество строк массива: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[][] mass = new int[n][];
            int just_zero = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите значения для строки {i + 1} через пробел: ");
                string[] inputValues = Console.ReadLine().Split(' ');

                mass[i] = new int[inputValues.Length];
                for (int j = 0; j < inputValues.Length; j++)
                {
                    if (int.TryParse(inputValues[j], out int value))
                    {
                        mass[i][j] = value;
                    }
                    else
                    {
                        mass[i][j] = 0;
                    }
                }
            }

            Console.WriteLine("Массив:");
            PrintMass(mass);

            for (int i = 0; i < n; i++)
            {
                int min, max, sum;
                CalceStats(ref mass[i], out min, out max, out sum, in just_zero);


                Console.WriteLine($"Строка {i + 1}: Минимум = {min}, Максимум = {max}, Сумма = {sum}");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите положительное число.");
        }
    }

    static void PrintMass(int[][] array)
    {
        foreach (var row in array)
        {
            foreach (var value in row)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
    }

    static void CalceStats(ref int[] row, out int min, out int max, out int sum, in int just_zero)
    {
        if (row.Length == 0)
        {
            min = max = sum = just_zero;
            return;
        }

        min = max = sum = row[0];

        for (int i = 1; i < row.Length; i++)
        {
            int value = row[i];
            if (value < min)
            {
                min = value;
            }
            if (value > max)
            {
                max = value;
            }
            sum += value;
        }
    }
}