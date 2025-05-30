namespace LabA4_HashFunc.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearchISBN;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGenerate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearchISBN = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtISBN
            this.txtISBN.Location = new System.Drawing.Point(20, 20);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.PlaceholderText = "ISBN (число)";
            this.txtISBN.Size = new System.Drawing.Size(150, 23);
            this.txtISBN.TabIndex = 0;

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(20, 50);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Название книги";
            this.txtTitle.Size = new System.Drawing.Size(300, 23);
            this.txtTitle.TabIndex = 1;

            // txtAuthor
            this.txtAuthor.Location = new System.Drawing.Point(20, 80);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.PlaceholderText = "Автор";
            this.txtAuthor.Size = new System.Drawing.Size(300, 23);
            this.txtAuthor.TabIndex = 2;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(340, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить книгу";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // txtSearchISBN
            this.txtSearchISBN.Location = new System.Drawing.Point(20, 120);
            this.txtSearchISBN.Name = "txtSearchISBN";
            this.txtSearchISBN.PlaceholderText = "ISBN для поиска";
            this.txtSearchISBN.Size = new System.Drawing.Size(150, 23);
            this.txtSearchISBN.TabIndex = 4;

            // btnFind
            this.btnFind.Location = new System.Drawing.Point(180, 115);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(120, 30);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Найти книгу";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);

            // btnDisplay
            this.btnDisplay.Location = new System.Drawing.Point(320, 115);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(140, 30);
            this.btnDisplay.TabIndex = 6;
            this.btnDisplay.Text = "Показать таблицу";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);

            // btnGenerate — сдвину вниз, чтобы не перекрывалось
            this.btnGenerate.Location = new System.Drawing.Point(340, 160);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 30);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Сгенерировать 20 книг";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // txtOutput
            this.txtOutput.Location = new System.Drawing.Point(20, 200);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(470, 160);
            this.txtOutput.TabIndex = 8;

            // MainForm
            this.ClientSize = new System.Drawing.Size(510, 380);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearchISBN);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOutput);
            this.Name = "MainForm";
            this.Text = "Хеш-таблица книг";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
