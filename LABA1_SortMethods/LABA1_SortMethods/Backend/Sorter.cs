namespace LABA1_SortMethods.Backend;

public enum SortMethod
{
    Bubble,
    Selection,
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
                throw new ArgumentException("Неподдерживаемый метод сортировки для массива");
        }
    }
    
    private static void SelectionSort(int[] array, out int comparisons, out int swaps)
    {
        comparisons = 0; // Счётчик сравнений
        swaps = 0;       // Счётчик перестановок

        for (int i = 0; i < array.Length - 1; i++) // Проходим по всем элементам, кроме последнего
        {
            int min = i; // Считаем текущий элемент минимальным

            for (int j = i + 1; j < array.Length; j++) // Ищем минимальный элемент в оставшейся части
            {
                comparisons++; // Сравнение текущего и минимального
                if (array[j] < array[min])
                    min = j; // Нашли новый минимум — запоминаем его индекс
            }

            if (min != i) // Если нашли элемент меньше текущего
            {
                (array[i], array[min]) = (array[min], array[i]); // Меняем местами
                swaps++; // Увеличиваем счётчик перестановок
            }
        }
    }

    private static void BubbleSort(int[] array, out int comparisons, out int swaps)
    {
        comparisons = 0; // Счётчик сравнений
        swaps = 0;       // Счётчик перестановок

        for (int i = 0; i < array.Length - 1; i++) // Проходим несколько "волн"
        {
            bool swapped = false; // Флаг, была ли хоть одна пере   становка

            for (int j = 0; j < array.Length - i - 1; j++) // Проход по неотсортированной части
            {
                comparisons++; // Каждое сравнение элементов

                if (array[j] > array[j + 1]) // Если элементы в неправильном порядке
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]); // Меняем местами
                    swaps++; // Увеличиваем счётчик перестановок
                    swapped = true; // Фиксируем, что была перестановка
                }
            }

            if (!swapped) break; // Если не было перестановок — массив уже отсортирован, выходим
        }
    }

}