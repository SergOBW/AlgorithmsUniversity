using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LABA1_SortMethods.Frontend
{
    public partial class ResultsPreviewForm : Form
    {
        public ResultsPreviewForm(List<string[]> rows)
        {
            InitializeComponent();

            // Добавляем столбцы
            string[] columns = { "Размер", "Метод", "Время (мс)", "Сравнения", "Обмены" };
            foreach (var col in columns)
            {
                dataGridViewResults.Columns.Add(col, col);
            }

            // Добавляем строки (пропускаем заголовок из rows[0], если есть)
            // Если rows включает заголовок, можно пропустить первый элемент
            int startIndex = 0;
            if (rows.Count > 0 && rows[0][0].ToLower().Contains("размер")) startIndex = 1;

            for (int i = startIndex; i < rows.Count; i++)
            {
                dataGridViewResults.Rows.Add(rows[i]);
            }
        }

        // Показывать диалог и проверить, нажал ли пользователь "Сохранить"
        public bool ShouldSave => DialogResult == DialogResult.OK;

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