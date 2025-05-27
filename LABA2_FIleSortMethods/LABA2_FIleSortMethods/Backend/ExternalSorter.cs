using System.Text;
using LABA1_SortMethods.Backend;

namespace LABA2_FIleSortMethods.Backend;

public static class ExternalSorter
{
    private static string? _inputFile;
    private static string? _outputFile;
    private static int[]? _sortedArray;

    public static void Generate(ArrayType type, int size)
    {
        string tempDir = AppDomain.CurrentDomain.BaseDirectory;
        _inputFile = Path.Combine(tempDir, $"input_{Guid.NewGuid()}.txt");

        int[] data = new int[size];
        var rand = new Random();

        switch (type)
        {
            case ArrayType.Random:
                for (int i = 0; i < size; i++)
                    data[i] = rand.Next(0, 1000);
                break;

            case ArrayType.Sorted:
                for (int i = 0; i < size; i++)
                    data[i] = i;
                break;

            case ArrayType.Reversed:
                for (int i = 0; i < size; i++)
                    data[i] = size - i;
                break;
        }

        File.WriteAllLines(_inputFile, data.Select(x => x.ToString()), Encoding.UTF8);
    }
    

    public static void Sort(SortMethod method, out int comparisons, out int swaps)
    {
        if (_inputFile == null)
            throw new InvalidOperationException("Файл не сгенерирован. Сначала вызови Generate().");

        string tempDir = AppDomain.CurrentDomain.BaseDirectory;
        _outputFile = Path.Combine(tempDir, $"output_{Guid.NewGuid()}.txt");

        switch (method)
        {
            case SortMethod.NaturalMerge:
                StraightMergeSort(_inputFile, _outputFile, out comparisons, out swaps);
                break;

            case SortMethod.PolyphaseMerge:
                PolyphaseMergeSort(_inputFile, _outputFile, out comparisons, out swaps);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(method), method, "Неизвестный метод сортировки.");
        }

        _sortedArray = File.ReadAllLines(_outputFile, Encoding.UTF8)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(int.Parse)
            .ToArray();
    }

    public static void StraightMergeSort(string inputPath, string outputPath, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;

        string tempFile1 = "temp1.txt";
        string tempFile2 = "temp2.txt";

        bool isSorted = false;

        while (!isSorted)
        {
            using (var reader = new StreamReader(inputPath, Encoding.UTF8))
            using (var writer1 = new StreamWriter(tempFile1, false, Encoding.UTF8))
            using (var writer2 = new StreamWriter(tempFile2, false, Encoding.UTF8))
            {
                bool writeToFirst = true;
                while (!reader.EndOfStream)
                {
                    string? line1 = reader.ReadLine();
                    string? line2 = reader.EndOfStream ? null : reader.ReadLine();

                    if (writeToFirst)
                    {
                        if (line1 != null) writer1.WriteLine(line1);
                        if (line2 != null) writer1.WriteLine(line2);
                    }
                    else
                    {
                        if (line1 != null) writer2.WriteLine(line1);
                        if (line2 != null) writer2.WriteLine(line2);
                    }

                    writeToFirst = !writeToFirst;
                }
            }

            using var reader1 = new StreamReader(tempFile1, Encoding.UTF8);
            using var reader2 = new StreamReader(tempFile2, Encoding.UTF8);
            using (var writer = new StreamWriter(_outputFile, false, Encoding.UTF8))
            {
                isSorted = MergeRuns(reader1, reader2, writer, ref comparisons, ref swaps);
                File.Copy(outputPath, inputPath, true);
            }
        }

        File.Delete(tempFile1);
        File.Delete(tempFile2);
    }

    private static bool MergeRuns(StreamReader reader1, StreamReader reader2, StreamWriter writer, ref int comparisons, ref int swaps)
    {
        bool sorted = true;
        string? line1 = reader1.ReadLine();
        string? line2 = reader2.ReadLine();
        
        Console.WriteLine(line1);


        while (line1 != null && line2 != null)
        {
            int a = int.Parse(line1);
            int b = int.Parse(line2);
            comparisons++;

            if (a <= b)
            {
                writer.WriteLine(a);
                line1 = reader1.ReadLine();
            }
            else
            {
                writer.WriteLine(b);
                line2 = reader2.ReadLine();
                sorted = false;
                swaps++;
            }
        }

        while (line1 != null)
        {
            writer.WriteLine(line1);
            line1 = reader1.ReadLine();
        }

        while (line2 != null)
        {
            writer.WriteLine(line2);
            line2 = reader2.ReadLine();
        }
        
        return sorted;
    }

    #region PolyphaseMergeSort

    private static void PolyphaseMergeSort(string inputPath, string outputPath, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        string fileA = "poly_A.txt";
        string fileB = "poly_B.txt";
        string fileC = "poly_C.txt";

        GenerateInitialRuns(inputPath, fileA, fileB);

        while (true)
        {
            bool aHasData = new FileInfo(fileA).Length > 0;
            bool bHasData = new FileInfo(fileB).Length > 0;

            if (!aHasData || !bHasData)
                break;

            MergeRuns(fileA, fileB, fileC, out comparisons, out swaps);
            (fileA, fileB, fileC) = (fileC, fileA, fileB);
        }

        string sortedFile = File.Exists(fileA) && new FileInfo(fileA).Length > 0 ? fileA : fileB;

        File.WriteAllText(outputPath, string.Empty, Encoding.UTF8);

        using (var reader = new StreamReader(sortedFile, Encoding.UTF8))
        using (var writer = new StreamWriter(_outputFile, false, Encoding.UTF8))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != "#")
                    writer.WriteLine(line);
            }
        }
    }

    private static void GenerateInitialRuns(string inputPath, string fileA, string fileB)
    {
        var lines = File.ReadLines(inputPath, Encoding.UTF8)
            .Where(line => int.TryParse(line, out _))
            .Select(int.Parse)
            .ToList();

        int runSize = 10;
        int runCount = (int)Math.Ceiling(lines.Count / (double)runSize);

        using (var writerA = new StreamWriter(fileA, false, Encoding.UTF8))
        using (var writerB = new StreamWriter(fileB, false, Encoding.UTF8))
        {
            for (int i = 0; i < runCount; i++)
            {
                var run = lines.Skip(i * runSize).Take(runSize).OrderBy(x => x).ToList();
                var writer = i % 2 == 0 ? writerA : writerB;

                foreach (var number in run)
                    writer.WriteLine(number);

                writer.WriteLine("#");
            }
        }

        File.WriteAllText("poly_C.txt", string.Empty, Encoding.UTF8);
    }

    private static void MergeRuns(string inputFile1, string inputFile2, string outputFile, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        using var reader1 = new StreamReader(inputFile1, Encoding.UTF8);
        using var reader2 = new StreamReader(inputFile2, Encoding.UTF8);
        using var writer = new StreamWriter(outputFile, false, Encoding.UTF8);

        while (!reader1.EndOfStream || !reader2.EndOfStream)
        {
            var run1 = ReadNextRun(reader1);
            var run2 = ReadNextRun(reader2);

            var merged = MergeTwoRuns(run1, run2, out int cmp, out int swp);
            comparisons += cmp;
            swaps += swp;

            foreach (var number in merged)
                writer.WriteLine(number);

            writer.WriteLine("#");
        }
    }

    private static List<int> MergeTwoRuns(List<int> run1, List<int> run2, out int comparisons, out int swaps)
    {
        var result = new List<int>();
        int i = 0, j = 0;
        comparisons = 0;
        swaps = 0;

        while (i < run1.Count && j < run2.Count)
        {
            comparisons++;
            if (run1[i] <= run2[j])
            {
                result.Add(run1[i++]);
            }
            else
            {
                result.Add(run2[j++]);
                swaps++;
            }
        }

        while (i < run1.Count) result.Add(run1[i++]);
        while (j < run2.Count) result.Add(run2[j++]);

        return result;
    }

    private static List<int> ReadNextRun(StreamReader reader)
    {
        var run = new List<int>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == "#")
                break;

            if (int.TryParse(line, out int number))
                run.Add(number);
        }

        return run;
    }

    #endregion

    public static int[] GetLastSortedArray()
    {
        if (_sortedArray == null)
            throw new InvalidOperationException("Сортировка ещё не была выполнена.");

        return _sortedArray;
    }
}
