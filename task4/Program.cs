//Задайте двумерный массив из целых чисел. Определите, есть столбец в массиве, сумма которого, 
// больше суммы элементов расположенных в четырех "углах" двумерного массива.

int ReadNumber(string message)
{
    int number = 0;
    while (true)
    {
        Console.WriteLine("Введите " + message);
        if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.WriteLine("Некорректный ввод");
        }
        else break;
    }
    return number;
}

int[,] CreateArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    return array;
}

int[,] FillArray(int[,] array)
{
    int[,] fillArray = new int[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < fillArray.GetLength(0); i++)
    {
        for (int j = 0; j < fillArray.GetLength(1); j++)
        {
            fillArray[i, j] = new Random().Next(0, 11);
        }
    }
    return fillArray;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Console.Write(array[i, j] + "   ");
            }
            else Console.Write(array[i, j] + "  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] getSumColumnsArray(int[,] array)
{
    int[] sumColumnArray = new int[array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumColumnArray[j] += array[i, j];
        }
    }
    return sumColumnArray;
}

int getSumAngles(int[,] array)
{
    int sumAngles = 0;
    sumAngles = array[0, 0] + array[0, array.GetLength(1) - 1] + array[array.GetLength(0) - 1, 0] + array[array.GetLength(0) - 1, array.GetLength(1) - 1];
    return sumAngles;
}

bool IsSumColumnMoreSumAngles(int[] sumColumnsArray, int sumAngles)
{
    return sumColumnsArray.Max() > sumAngles;
}

void PrintResult(int[,] array)
{
    int[] sumColumns = getSumColumnsArray(array);
    int sumAngles = getSumAngles(array);
    if (IsSumColumnMoreSumAngles(sumColumns, sumAngles))
    {
        Console.WriteLine($"Да. {sumAngles}<{sumColumns.Max()}");
    }
    else
    {
        Console.WriteLine($"Нет. {sumAngles}>{sumColumns.Max()}");
    }
    Console.WriteLine($"Значение суммы углов: {sumAngles};  Значения сумм столбцов: {String.Join(" ", sumColumns)}");
}

Console.Clear();

int[,] array = FillArray(CreateArray(ReadNumber("количество строк"), ReadNumber("количество столбцов")));
PrintArray(array);
PrintResult(array);