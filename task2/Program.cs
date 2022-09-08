// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

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

int[,] FillArray(int[,] array, int min, int max)
{
    int[,] fillArray = new int[array.GetLength(0), array.GetLength(1)];
    for (int i = 0; i < fillArray.GetLength(0); i++)
    {
        for (int j = 0; j < fillArray.GetLength(1); j++)
        {
            fillArray[i, j] = new Random().Next(min, max + 1);
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
void FindElementByIndex(int[,] array, int row, int column)
{
    if (row < array.GetLength(0) && column < array.GetLength(1))
    {
        Console.WriteLine($"Элемент=[{row},{column}]={array[row, column]}");
    }
    else Console.WriteLine("Элемента с таким индексом нет");
}

Console.Clear();
int[,] array = FillArray(CreateArray(ReadNumber("количество строк"), ReadNumber("количество столбцов")), -10, 10);
PrintArray(array);
FindElementByIndex(array, ReadNumber("индекс строки"), ReadNumber("индекс столбца"));