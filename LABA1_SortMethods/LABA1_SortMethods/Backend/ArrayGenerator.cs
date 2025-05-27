namespace LABA1_SortMethods.Backend;

public enum ArrayType
{
    Random,
    Sorted,
    Reversed
}

public static class ArrayGenerator
{
    public static int[] Generate(ArrayType type, int size, int min = 0, int max = 1000)
    {
        var rand = new Random();

        return type switch
        {
            ArrayType.Random => Enumerable.Range(0, size).Select(_ => rand.Next(min, max + 1)).ToArray(),
            ArrayType.Sorted => Enumerable.Range(min, size).ToArray(),
            ArrayType.Reversed => Enumerable.Range(min, size).Reverse().ToArray(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), "Неизвестный тип массива")
        };
    }
}