using System;
using System.Diagnostics;
using LABA1_SortMethods.Backend;

namespace LABA1_SortMethods.Frontend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Заполняем ComboBox-ы
            comboBoxSortMethod1.Items.AddRange(Enum.GetValues(typeof(SortMethod)).Cast<object>().ToArray());
            comboBoxSortMethod1.SelectedIndex = 0;

            comboBoxArrayType.Items.AddRange(Enum.GetValues(typeof(ArrayType)).Cast<object>().ToArray());
            comboBoxArrayType.SelectedIndex = 0;
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(textBoxArraySize.Text);
                int min = int.Parse(textBoxMinValue.Text);
                int max = int.Parse(textBoxMaxValue.Text);

                if (radioButtonSingle.Checked)
                {
                    var sortMethod = (SortMethod)comboBoxSortMethod1.SelectedItem;
                    var array = ArrayGenerator.Generate(ArrayType.Random, size, min, max);
                    var arrayCopy = (int[])array.Clone();

                    var sw = Stopwatch.StartNew();
                    Sorter.Sort(arrayCopy, sortMethod, out int comparisons, out int swaps);
                    sw.Stop();

                    MessageBox.Show(
                        $"Метод: {sortMethod}\nВремя: {sw.ElapsedMilliseconds} мс\nСравнений: {comparisons}\nОбменов: {swaps}",
                        "Результат");
                }
                else
                {
                    int step = int.Parse(textBoxStep.Text);
                    string outputFile = textBoxOutputFile.Text;
                    var arrayType = (ArrayType)comboBoxArrayType.SelectedItem;

                    using var writer = new StreamWriter(outputFile);
                    writer.WriteLine("Size,Method,Time(ms),Comparisons,Swaps");

                    for (int currentSize = step; currentSize <= size; currentSize += step)
                    {
                        foreach (SortMethod method in Enum.GetValues(typeof(SortMethod)))
                        {
                            var array = ArrayGenerator.Generate(arrayType, currentSize, min, max);
                            var copy = (int[])array.Clone();

                            var sw = Stopwatch.StartNew();
                            Sorter.Sort(copy, method, out int cmp, out int swp);
                            sw.Stop();

                            writer.WriteLine($"{currentSize},{method},{sw.ElapsedMilliseconds},{cmp},{swp}");
                        }
                    }

                    MessageBox.Show("Статистика записана в файл", "Готово");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
