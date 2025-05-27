using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LABA1_SortMethods.Backend
{
    public static class BenchmarkRunner
    {
        // Метод сбора данных, возвращает список строк с данными
        public static List<string[]> CollectBenchmarkData(
            int minSize,
            int maxSize,
            int step,
            int minValue,
            int maxValue,
            ArrayType arrayType)
        {
            var results = new List<string[]>();

            for (int size = minSize; size <= maxSize; size += step)
            {
                foreach (SortMethod method in Enum.GetValues(typeof(SortMethod)))
                {
                    var array = ArrayGenerator.Generate(arrayType, size, minValue, maxValue);
                    var copy = (int[])array.Clone();

                    var sw = Stopwatch.StartNew();
                    Sorter.Sort(copy, method, out int comparisons, out int swaps);
                    sw.Stop();

                    results.Add(new string[]
                    {
                        size.ToString(),
                        method.ToString(),
                        sw.ElapsedMilliseconds.ToString(),
                        comparisons.ToString(),
                        swaps.ToString()
                    });
                }
            }

            return results;
        }

        // Метод сохранения данных в CSV с разделителем ; и UTF-8 BOM
        public static void SaveToCsv(string path, List<string[]> data)
        {
            using var writer = new StreamWriter(path, false, new UTF8Encoding(true));
            writer.WriteLine("Размер;Метод;Время(мс);Сравнения;Обмены"); // Заголовок

            foreach (var row in data)
            {
                // Объединяем с разделителем ; — учитываем, что сами значения не содержат ;
                writer.WriteLine(string.Join(";", row));
            }
        }
    }
}