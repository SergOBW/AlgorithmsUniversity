using LABA1_SortMethods.Backend;

namespace LABA1_SortMethods.Frontend
{
    public partial class ResultsPreviewForm : Form
    {
        private List<BenchmarkResult> data;

        public ResultsPreviewForm(List<BenchmarkResult> benchmarkData)
        {
            InitializeComponent();

            data = benchmarkData;

            // Настраиваем dataGridViewResults (если ещё не настроено в InitializeComponent)
            dataGridViewResults.AutoGenerateColumns = false;
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.MultiSelect = false;
            dataGridViewResults.RowHeadersVisible = false;

            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Размер", DataPropertyName = "Size" });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Метод", DataPropertyName = "Method" });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Время(мс)", DataPropertyName = "TimeMs" });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Сравнения", DataPropertyName = "Comparisons" });
            dataGridViewResults.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Обмены", DataPropertyName = "Swaps" });

            dataGridViewResults.DataSource = data;

            dataGridViewResults.SelectionChanged += DataGridViewResults_SelectionChanged;

            if (data.Any())
                ShowArray(data[0].SortedArray);
        }

        private void DataGridViewResults_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewResults.CurrentRow?.DataBoundItem is BenchmarkResult result)
            {
                ShowArray(result.SortedArray);
            }
            else
            {
                ShowArray(Array.Empty<int>());
            }
        }

        private void ShowArray(int[] array)
        {
            if (array == null)
                textBoxArray.Text = "";
            else
                textBoxArray.Text = string.Join(", ", array);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
