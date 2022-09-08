//Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

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
            fillArray[i, j] = ReadNumber($"число[{i},{j}]");
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
            Console.Write(array[i, j] + "  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

double[] AverageColumnsValue(int[,] array)
{
    double[] averageArray = new double[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            averageArray[j] += array[i, j];
        }
    }
    for (int i = 0; i < averageArray.Length; i++)
    {
        averageArray[i] = averageArray[i] / array.GetLength(0);
    }
    return averageArray;
}
void PrintAverageColumnsValue(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Среднее значение столбца {i} = {Math.Round(array[i], 2)}");
    }
}

Console.Clear();

int[,] array = FillArray(CreateArray(ReadNumber("количество строк"), ReadNumber("количество столбцов")));
PrintArray(array);
PrintAverageColumnsValue(AverageColumnsValue(array));