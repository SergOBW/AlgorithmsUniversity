using LABA1_SortMethods.Backend;

namespace LABA2_FIleSortMethods.Backend;

public static class FileGenerator
{
    public static void GenerateRandomFile(string path, int count, int minValue, int maxValue)
    {
        var rand = new Random();
        var numbers = new int[count];
        for (int i = 0; i < count; i++)
            numbers[i] = rand.Next(minValue, maxValue + 1);

        WriteToFile(path, numbers);
    }

    public static void GenerateOrderedFile(string path, int count, int minValue, int maxValue)
    {
        var rand = new Random();
        var numbers = new int[count];
        for (int i = 0; i < count; i++)
            numbers[i] = rand.Next(minValue, maxValue + 1);

        Array.Sort(numbers);
        WriteToFile(path, numbers);
    }

    public static void GenerateReverseOrderedFile(string path, int count, int minValue, int maxValue)
    {
        var rand = new Random();
        var numbers = new int[count];
        for (int i = 0; i < count; i++)
            numbers[i] = rand.Next(minValue, maxValue + 1);

        Array.Sort(numbers);
        Array.Reverse(numbers);
        WriteToFile(path, numbers);
    }

    private static void WriteToFile(string path, int[] numbers)
    {
        using var writer = new StreamWriter(path);
        foreach (var num in numbers)
            writer.WriteLine(num);
    }

    public static int[] GenerateAndGetCopy(ArrayType arrayType, int size, int minValue, int maxValue)
    {
        string tempDir = AppDomain.CurrentDomain.BaseDirectory;
        string inputFile = Path.Combine(tempDir, $"input_{size}.txt");
        
        switch (arrayType)
        {
            case ArrayType.Random:
                GenerateRandomFile(inputFile, size, minValue, maxValue);
                break;
            case ArrayType.Sorted:
                GenerateOrderedFile(inputFile, size, minValue, maxValue);
                break;
            case ArrayType.Reversed:
               GenerateReverseOrderedFile(inputFile, size, minValue, maxValue);
                break;
        }

        return new []{ 0};
    }
}
