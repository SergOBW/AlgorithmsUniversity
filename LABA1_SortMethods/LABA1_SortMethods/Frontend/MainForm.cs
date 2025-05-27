using System.Diagnostics;
using LABA1_SortMethods.Backend;

namespace LABA1_SortMethods.Frontend
{
    public partial class MainForm : Form
    {
        private const string LastPathFile = "last_path.txt";

        // Максимально допустимый размер массива, чтобы не "убить" компьютер
        private const int MaxArraySize = 10000;

        public MainForm()
        {
            InitializeComponent();

            comboBoxSortMethod1.Items.AddRange(Enum.GetValues(typeof(SortMethod)).Cast<object>().ToArray());
            comboBoxSortMethod1.SelectedIndex = 0;

            comboBoxArrayType.Items.AddRange(Enum.GetValues(typeof(ArrayType)).Cast<object>().ToArray());
            comboBoxArrayType.SelectedIndex = 0;

            if (File.Exists(LastPathFile))
                textBoxOutputFile.Text = File.ReadAllText(LastPathFile);
            else
                textBoxOutputFile.Text = "output.csv";
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                FileName = textBoxOutputFile.Text
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputFile.Text = sfd.FileName;
                File.WriteAllText(LastPathFile, sfd.FileName);
            }
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(textBoxArraySize.Text);
                int minValue = int.Parse(textBoxMinValue.Text);
                int maxValue = int.Parse(textBoxMaxValue.Text);

                if (size > MaxArraySize)
                {
                    MessageBox.Show($"Размер массива слишком большой! Максимум {MaxArraySize}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (radioButtonSingle.Checked)
                {
                    var sortMethod = (SortMethod)comboBoxSortMethod1.SelectedItem;
                    var array = ArrayGenerator.Generate(ArrayType.Random, size, minValue, maxValue);
                    var arrayCopy = (int[])array.Clone();

                    var sw = Stopwatch.StartNew();
                    Sorter.Sort(arrayCopy, sortMethod, out int comparisons, out int swaps);
                    sw.Stop();

                    var resultForm = new ResultForm(sortMethod.ToString(), sw.ElapsedMilliseconds, comparisons, swaps, arrayCopy);

                    resultForm.ShowDialog();
                }
                else // Режим сравнения
                {
                    int step = int.Parse(textBoxStep.Text);
                    var arrayType = (ArrayType)comboBoxArrayType.SelectedItem;
                    string outputFile = textBoxOutputFile.Text.Trim();

                    if (string.IsNullOrWhiteSpace(outputFile))
                        outputFile = "output.csv";
                    if (!Path.IsPathRooted(outputFile))
                        outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputFile);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile)!);
                    File.WriteAllText(LastPathFile, outputFile);

                    // Запускаем сбор данных на бекенде (тяжёлая работа здесь)
                    var data = BenchmarkRunner.CollectBenchmarkData(minSize: 0, maxSize: size, step: step, minValue: minValue, maxValue: maxValue, arrayType: arrayType);

                    using var previewForm = new ResultsPreviewForm(data);
                    if (previewForm.ShowDialog() == DialogResult.OK)
                    {
                        BenchmarkRunner.SaveToCsv(outputFile, data);
                        MessageBox.Show("Файл успешно сохранён:\n" + outputFile, "Готово");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
