namespace LABA1_SortMethods.Frontend;
partial class ResultsPreviewForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dataGridViewResults;
    private System.Windows.Forms.TextBox textBoxArray;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonCancel;

    private void InitializeComponent()
    {
        this.dataGridViewResults = new System.Windows.Forms.DataGridView();
        this.textBoxArray = new System.Windows.Forms.TextBox();
        this.buttonSave = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();

        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();

        this.SuspendLayout();

        // dataGridViewResults
        this.dataGridViewResults.AllowUserToAddRows = false;
        this.dataGridViewResults.AllowUserToDeleteRows = false;
        this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                | System.Windows.Forms.AnchorStyles.Right))));
        this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridViewResults.Location = new System.Drawing.Point(12, 12);
        this.dataGridViewResults.MultiSelect = false;
        this.dataGridViewResults.ReadOnly = true;
        this.dataGridViewResults.RowHeadersVisible = false;
        this.dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dataGridViewResults.Size = new System.Drawing.Size(560, 250);
        this.dataGridViewResults.TabIndex = 0;

        // textBoxArray
        this.textBoxArray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                            | System.Windows.Forms.AnchorStyles.Right)));
        this.textBoxArray.Location = new System.Drawing.Point(12, 270);
        this.textBoxArray.Multiline = true;
        this.textBoxArray.ReadOnly = true;
        this.textBoxArray.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBoxArray.Font = new System.Drawing.Font("Consolas", 9F);
        this.textBoxArray.Size = new System.Drawing.Size(560, 70);
        this.textBoxArray.TabIndex = 3;

        // buttonSave
        this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.buttonSave.Location = new System.Drawing.Point(400, 350);
        this.buttonSave.Name = "buttonSave";
        this.buttonSave.Size = new System.Drawing.Size(85, 30);
        this.buttonSave.TabIndex = 1;
        this.buttonSave.Text = "Сохранить";
        this.buttonSave.UseVisualStyleBackColor = true;
        this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

        // buttonCancel
        this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.buttonCancel.Location = new System.Drawing.Point(490, 350);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(85, 30);
        this.buttonCancel.TabIndex = 2;
        this.buttonCancel.Text = "Отмена";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

        // ResultsPreviewForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.ClientSize = new System.Drawing.Size(584, 391);
        this.Controls.Add(this.dataGridViewResults);
        this.Controls.Add(this.textBoxArray);
        this.Controls.Add(this.buttonSave);
        this.Controls.Add(this.buttonCancel);
        this.MinimumSize = new System.Drawing.Size(600, 430);
        this.Name = "ResultsPreviewForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Предварительный просмотр результатов";

        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }
}
