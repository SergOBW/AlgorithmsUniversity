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
        private Button buttonBrowse;
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
            this.Text = "Сортировка массивов";
            this.Size = new Size(600, 450);

            labelMode = new Label { Text = "Режим работы:", Location = new Point(20, 20) };
            radioButtonSingle = new RadioButton { Text = "Одиночная сортировка", Location = new Point(150, 20), Checked = true };
            radioButtonStats = new RadioButton { Text = "Сбор статистики", Location = new Point(330, 20) };
            radioButtonSingle.CheckedChanged += ModeChanged;
            radioButtonStats.CheckedChanged += ModeChanged;

            labelSize = new Label { Text = "Размер массива:", Location = new Point(20, 60) };
            textBoxArraySize = new TextBox { Location = new Point(150, 60), Width = 100 };

            labelMin = new Label { Text = "Мин. значение:", Location = new Point(20, 100) };
            textBoxMinValue = new TextBox { Location = new Point(150, 100), Width = 100 };

            labelMax = new Label { Text = "Макс. значение:", Location = new Point(20, 140) };
            textBoxMaxValue = new TextBox { Location = new Point(150, 140), Width = 100 };

            labelSortMethod = new Label { Text = "Метод сортировки:", Location = new Point(20, 180) };
            comboBoxSortMethod1 = new ComboBox { Location = new Point(150, 180), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            labelArrayType = new Label { Text = "Тип массива:", Location = new Point(20, 220) };
            comboBoxArrayType = new ComboBox { Location = new Point(150, 220), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            labelStep = new Label { Text = "Шаг размера:", Location = new Point(20, 260) };
            textBoxStep = new TextBox { Location = new Point(150, 260), Width = 100 };

            labelOutput = new Label { Text = "Файл вывода:", Location = new Point(20, 300) };
            textBoxOutputFile = new TextBox { Location = new Point(150, 300), Width = 200 };
            
            buttonBrowse = new Button { Text = "Обзор...", Location = new Point(360, 300), Width = 80 };
            buttonBrowse.Click += ButtonBrowse_Click;

            buttonRun = new Button { Text = "Выполнить", Location = new Point(20, 350), Width = 120 };
            buttonRun.Click += ButtonRun_Click;

            Controls.AddRange(new Control[] {
                labelMode, radioButtonSingle, radioButtonStats,
                labelSize, textBoxArraySize,
                labelMin, textBoxMinValue,
                labelMax, textBoxMaxValue,
                labelSortMethod, comboBoxSortMethod1,
                labelArrayType, comboBoxArrayType,
                labelStep, textBoxStep,
                labelOutput, textBoxOutputFile,
                buttonRun, buttonBrowse
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
            textBoxOutputFile.Visible = show;
            labelOutput.Visible = show;
            buttonBrowse.Visible = show;
            labelSortMethod.Visible = !show;
            comboBoxSortMethod1.Visible = !show;
        }
    }
}
