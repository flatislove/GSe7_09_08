//Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

int ReadNumber(string message)
{
    int number = 0;
    while (true)
    {
        Console.WriteLine("Введите количество " + message);
        if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
        {
            Console.WriteLine("Некорректный ввод");
        }
        else break;
    }
    return number;
}

double[,] CreateArray(int rows, int columns)
{
    double[,] array = new double[rows, columns];
    return array;
}

double[,] FillArray(double[,] array, int min, int max)
{
    double[,] fillArray = new double[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < fillArray.GetLength(0); i++)
    {
        for (int j = 0; j < fillArray.GetLength(1); j++)
        {
            fillArray[i, j] = min + new Random().NextDouble() * (max - min);
        }
    }
    return fillArray;
}
void PrintArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(Math.Round(array[i, j], 2) + "  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.Clear();

PrintArray(FillArray(CreateArray(ReadNumber("строк"), ReadNumber("столбцов")), -10, 10));