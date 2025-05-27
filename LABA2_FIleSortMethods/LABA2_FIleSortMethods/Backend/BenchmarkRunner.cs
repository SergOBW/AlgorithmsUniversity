using System.Diagnostics;
using System.Text;
using LABA2_FIleSortMethods.Backend;

namespace LABA1_SortMethods.Backend
{
    public class BenchmarkResult
    {
        public int Size { get; set; }
        public SortMethod Method { get; set; }
        public long TimeMs { get; set; }
        public int Comparisons { get; set; }
        public int Swaps { get; set; }
        public int[] SortedArray { get; set; }  // Итоговый массив
    }

    public enum SortMethod
    {
        NaturalMerge,
        PolyphaseMerge,
    }

    public enum ArrayType
    {
        Random,
        Sorted,
        Reversed
    }

    public static class BenchmarkRunner
    {
        // Метод сбора данных, возвращает список строк с данными
        public static List<BenchmarkResult> CollectBenchmarkData(int minSize, int maxSize, int step, int minValue, int maxValue, ArrayType arrayType)
        {
            var results = new List<BenchmarkResult>();

            for (int size = minSize; size <= maxSize; size += step)
            {
                foreach (SortMethod method in Enum.GetValues(typeof(SortMethod)))
                {
                    
                    var sw = Stopwatch.StartNew();
                    ExternalSorter.Generate(arrayType, size);
                    ExternalSorter.Sort( method, out int comparisons, out int swaps);
                    sw.Stop();
                    
                    Console.WriteLine($"{method}: {sw.ElapsedMilliseconds}ms");

                    results.Add(new BenchmarkResult
                    {
                        Size = size,
                        Method = method,
                        TimeMs = sw.ElapsedMilliseconds,
                        Comparisons = comparisons,
                        Swaps = swaps,
                        SortedArray =  ExternalSorter.GetLastSortedArray()
                    });
                }
            }

            return results;
        }



        // Метод сохранения данных в CSV с разделителем ; и UTF-8 BOM
        public static void SaveToCsv(string path, List<BenchmarkResult> results)
        {
            using var writer = new StreamWriter(path, false, new UTF8Encoding(true));
            writer.WriteLine("Размер;Метод;Время(мс);Сравнения;Обмены;Итоговый массив");

            foreach (var result in results)
            {
                // Превращаем итоговый массив в строку с разделителем запятая, например: "1,2,3,4"
                string arrayStr = result.SortedArray != null 
                    ? string.Join(",", result.SortedArray) 
                    : "";

                // Формируем строку с данными, экранируя или фильтруя, если нужно (здесь простой вариант)
                var row = new string[]
                {
                    result.Size.ToString(),
                    result.Method.ToString(),
                    result.TimeMs.ToString(),
                    result.Comparisons.ToString(),
                    result.Swaps.ToString(),
                    arrayStr
                };

                writer.WriteLine(string.Join(";", row));
            }
        }
    }
}