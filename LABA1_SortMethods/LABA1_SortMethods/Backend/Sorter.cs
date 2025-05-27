namespace LABA1_SortMethods.Backend;

public enum SortMethod
{
    Bubble,
    Selection
}


public static class Sorter
{
    public static void Sort(int[] array, SortMethod method, out int comparisons, out int swaps)
    {
        switch (method)
        {
            case SortMethod.Bubble:
                BubbleSort(array, out comparisons, out swaps);
                break;
            case SortMethod.Selection:
                SelectionSort(array, out comparisons, out swaps);
                break;
            default:
                throw new ArgumentException("Неизвестный метод сортировки");
        }
    }
    
    private static void SelectionSort(int[] array, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                comparisons++;
                if (array[j] < array[min])
                    min = j;
            }

            if (min != i)
            {
                (array[i], array[min]) = (array[min], array[i]);
                swaps++;
            }
        }
    }

    private static void BubbleSort(int[] array, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                comparisons++;
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    swaps++;
                    swapped = true;
                }
            }

            if (!swapped) break;
        }
    }
}