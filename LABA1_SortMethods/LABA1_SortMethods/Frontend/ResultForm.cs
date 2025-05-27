using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LABA1_SortMethods.Frontend
{
    public class ResultForm : Form
    {
        public ResultForm(string method, long timeMs, int comparisons, int swaps, int[] sortedArray)
        {
            Text = "Результат сортировки";
            Size = new Size(500, 400);
            StartPosition = FormStartPosition.CenterParent;

            var labelMethod = new Label { Text = $"Метод сортировки: {method}", Location = new Point(20, 20), AutoSize = true };
            var labelTime = new Label { Text = $"Время выполнения: {timeMs} мс", Location = new Point(20, 50), AutoSize = true };
            var labelCmp = new Label { Text = $"Количество сравнений: {comparisons}", Location = new Point(20, 80), AutoSize = true };
            var labelSwaps = new Label { Text = $"Количество обменов: {swaps}", Location = new Point(20, 110), AutoSize = true };

            var arrayTextBox = new TextBox
            {
                Location = new Point(20, 140),
                Size = new Size(440, 180),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Font = new Font("Consolas", 10),
                WordWrap = false,
                Text = string.Join(", ", sortedArray)
            };

            var closeButton = new Button
            {
                Text = "Закрыть",
                Location = new Point(190, 330),
                Width = 100,
                DialogResult = DialogResult.OK
            };

            Controls.AddRange(new Control[] { labelMethod, labelTime, labelCmp, labelSwaps, arrayTextBox, closeButton });
        }
    }
}