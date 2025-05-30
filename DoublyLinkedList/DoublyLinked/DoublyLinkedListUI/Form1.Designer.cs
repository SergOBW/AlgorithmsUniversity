namespace DoublyLinked.DoublyLinkedListUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtInputList = new System.Windows.Forms.TextBox();
            this.btnBuildList = new System.Windows.Forms.Button();
            this.lblList = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbAddPosition= new System.Windows.Forms.ComboBox();
            this.cbRemovePosition= new System.Windows.Forms.ComboBox();
            this.txtRemoveIndex = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.rbFindByValue = new System.Windows.Forms.RadioButton();
            this.rbFindByIndex = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRemovePalindromes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInputList
            // 
            this.txtInputList.Location = new System.Drawing.Point(12, 12);
            this.txtInputList.Name = "txtInputList";
            this.txtInputList.Size = new System.Drawing.Size(300, 20);
            this.txtInputList.TabIndex = 0;
            this.txtInputList.PlaceholderText = "Введите числа через пробел";
            // 
            // btnBuildList
            // 
            this.btnBuildList.Location = new System.Drawing.Point(320, 10);
            this.btnBuildList.Name = "btnBuildList";
            this.btnBuildList.Size = new System.Drawing.Size(150, 23);
            this.btnBuildList.TabIndex = 1;
            this.btnBuildList.Text = "Построить список";
            this.btnBuildList.UseVisualStyleBackColor = true;
            this.btnBuildList.Click += new System.EventHandler(this.btnBuildList_Click);
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(12, 45);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(34, 13);
            this.lblList.TabIndex = 2;
            this.lblList.Text = "List: []";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(12, 70);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(70, 20);
            this.txtValue.TabIndex = 3;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(90, 70);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(40, 20);
            this.txtIndex.TabIndex = 4;
            // 
            // cbAddPosition
            // 
            this.cbAddPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddPosition.FormattingEnabled = true;
            this.cbAddPosition.Items.AddRange(new object[] {
            "В начало",
            "В конец",
            "По индексу"});
            this.cbAddPosition.Location = new System.Drawing.Point(140, 70);
            this.cbAddPosition.Name = "cbAddPosition";
            this.cbAddPosition.Size = new System.Drawing.Size(100, 21);
            this.cbAddPosition.TabIndex = 5;
            this.cbAddPosition.SelectedIndexChanged += new System.EventHandler(this.cbAddPosition_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(250, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbRemovePosition
            // 
            this.cbRemovePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemovePosition.FormattingEnabled = true;
            this.cbRemovePosition.Items.AddRange(new object[] {
            "С начала",
            "С конца",
            "По индексу"});
            this.cbRemovePosition.Location = new System.Drawing.Point(12, 110);
            this.cbRemovePosition.Name = "cbRemovePosition";
            this.cbRemovePosition.Size = new System.Drawing.Size(100, 21);
            this.cbRemovePosition.TabIndex = 7;
            this.cbRemovePosition.SelectedIndexChanged += new System.EventHandler(this.cbRemovePosition_SelectedIndexChanged);
            // 
            // txtRemoveIndex
            // 
            this.txtRemoveIndex.Location = new System.Drawing.Point(120, 110);
            this.txtRemoveIndex.Name = "txtRemoveIndex";
            this.txtRemoveIndex.Size = new System.Drawing.Size(40, 20);
            this.txtRemoveIndex.TabIndex = 8;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(170, 108);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(12, 150);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(70, 20);
            this.txtFind.TabIndex = 10;
            // 
            // rbFindByValue
            // 
            this.rbFindByValue.AutoSize = true;
            this.rbFindByValue.Checked = true;
            this.rbFindByValue.Location = new System.Drawing.Point(90, 150);
            this.rbFindByValue.Name = "rbFindByValue";
            this.rbFindByValue.Size = new System.Drawing.Size(88, 17);
            this.rbFindByValue.TabIndex = 11;
            this.rbFindByValue.TabStop = true;
            this.rbFindByValue.Text = "По значению";
            this.rbFindByValue.UseVisualStyleBackColor = true;
            // 
            // rbFindByIndex
            // 
            this.rbFindByIndex.AutoSize = true;
            this.rbFindByIndex.Location = new System.Drawing.Point(180, 150);
            this.rbFindByIndex.Name = "rbFindByIndex";
            this.rbFindByIndex.Size = new System.Drawing.Size(79, 17);
            this.rbFindByIndex.TabIndex = 12;
            this.rbFindByIndex.Text = "По индексу";
            this.rbFindByIndex.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(270, 147);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 23);
            this.btnFind.TabIndex = 13;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRemovePalindromes
            // 
            this.btnRemovePalindromes.Location = new System.Drawing.Point(12, 185);
            this.btnRemovePalindromes.Name = "btnRemovePalindromes";
            this.btnRemovePalindromes.Size = new System.Drawing.Size(200, 23);
            this.btnRemovePalindromes.TabIndex = 14;
            this.btnRemovePalindromes.Text = "Удалить палиндромы";
            this.btnRemovePalindromes.UseVisualStyleBackColor = true;
            this.btnRemovePalindromes.Click += new System.EventHandler(this.btnRemovePalindromes_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.Controls.Add(this.btnRemovePalindromes);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.rbFindByIndex);
            this.Controls.Add(this.rbFindByValue);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtRemoveIndex);
            this.Controls.Add(this.cbRemovePosition);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbAddPosition);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.btnBuildList);
            this.Controls.Add(this.txtInputList);
            this.Name = "Form1";
            this.Text = "Двусвязный список";
            this.ResumeLayout(false);
            this.PerformLayout();
            
            cbAddPosition.SelectedIndex = 0; // по умолчанию "В начало"
            cbRemovePosition.SelectedIndex = 0; // по умолчанию "С начала"
            cbAddPosition_SelectedIndexChanged(null, null); // обновляем видимость поля
            cbRemovePosition_SelectedIndexChanged(null, null);
        }

        #endregion

        private System.Windows.Forms.TextBox txtInputList;
        private System.Windows.Forms.Button btnBuildList;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.ComboBox cbAddPosition;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbRemovePosition;
        private System.Windows.Forms.TextBox txtRemoveIndex;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.RadioButton rbFindByValue;
        private System.Windows.Forms.RadioButton rbFindByIndex;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnRemovePalindromes;
    }
}
