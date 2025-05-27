using System.Windows.Forms;

namespace LABA1_SortMethods.Frontend
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboBoxSortMethod1;
        private ComboBox comboBoxSortMethod2;
        private ComboBox comboBoxArrayType;
        private TextBox textBoxArraySize;
        private TextBox textBoxMinValue;
        private TextBox textBoxMaxValue;
        private TextBox textBoxStep;
        private TextBox textBoxOutputFile;
        private RadioButton radioButtonSingle;
        private RadioButton radioButtonStats;
        private Button buttonRun;
        private Label labelMode;
        private Label labelSize;
        private Label labelMin;
        private Label labelMax;
        private Label labelStep;
        private Label labelSortMethod;
        private Label labelArrayType;
        private Label labelOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Text = "Сортировка массивов";
            this.Size = new System.Drawing.Size(600, 500);

            labelMode = new Label { Text = "Режим работы:", Location = new System.Drawing.Point(20, 20) };
            radioButtonSingle = new RadioButton { Text = "Одиночная сортировка", Location = new System.Drawing.Point(150, 20), Checked = true };
            radioButtonStats = new RadioButton { Text = "Статистика", Location = new System.Drawing.Point(330, 20) };
            radioButtonSingle.CheckedChanged += ModeChanged;
            radioButtonStats.CheckedChanged += ModeChanged;

            labelSize = new Label { Text = "Размер массива:", Location = new System.Drawing.Point(20, 60) };
            textBoxArraySize = new TextBox { Location = new System.Drawing.Point(150, 60), Width = 100 };

            labelMin = new Label { Text = "Мин. значение:", Location = new System.Drawing.Point(20, 100) };
            textBoxMinValue = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 100 };

            labelMax = new Label { Text = "Макс. значение:", Location = new System.Drawing.Point(20, 140) };
            textBoxMaxValue = new TextBox { Location = new System.Drawing.Point(150, 140), Width = 100 };

            labelSortMethod = new Label { Text = "Метод сортировки:", Location = new System.Drawing.Point(20, 180) };
            comboBoxSortMethod1 = new ComboBox { Location = new System.Drawing.Point(150, 180), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            labelArrayType = new Label { Text = "Тип массива (для статистики):", Location = new System.Drawing.Point(20, 220) };
            comboBoxArrayType = new ComboBox { Location = new System.Drawing.Point(230, 220), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            labelStep = new Label { Text = "Шаг размера:", Location = new System.Drawing.Point(20, 260) };
            textBoxStep = new TextBox { Location = new System.Drawing.Point(150, 260), Width = 100 };

            labelOutput = new Label { Text = "Файл вывода:", Location = new System.Drawing.Point(20, 300) };
            textBoxOutputFile = new TextBox { Location = new System.Drawing.Point(150, 300), Width = 200 };

            buttonRun = new Button { Text = "Выполнить", Location = new System.Drawing.Point(20, 350), Width = 120 };
            buttonRun.Click += ButtonRun_Click;

            this.Controls.AddRange(new Control[] {
                labelMode, radioButtonSingle, radioButtonStats,
                labelSize, textBoxArraySize,
                labelMin, textBoxMinValue,
                labelMax, textBoxMaxValue,
                labelSortMethod, comboBoxSortMethod1,
                labelArrayType, comboBoxArrayType,
                labelStep, textBoxStep,
                labelOutput, textBoxOutputFile,
                buttonRun
            });

            ToggleStatControls(false);
        }

        private void ModeChanged(object sender, EventArgs e)
        {
            ToggleStatControls(radioButtonStats.Checked);
        }

        private void ToggleStatControls(bool show)
        {
            comboBoxArrayType.Visible = show;
            labelArrayType.Visible = show;
            textBoxStep.Visible = show;
            labelStep.Visible = show;
        }
    }
}
