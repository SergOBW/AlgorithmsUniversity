using DoublyLinked.DoublyLinkedListLib;

namespace DoublyLinked.DoublyLinkedListUI

{
    public partial class Form1 : Form
    {
        private DoublyLinkedList list = new DoublyLinkedList();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtValue.Text, out int value))
            {
                if (cbAddPosition.SelectedIndex == 0)
                    list.AddFirst(value);
                else if (cbAddPosition.SelectedIndex == 1)
                    list.AddLast(value);
                else if (cbAddPosition.SelectedIndex == 2)
                {
                    int index = int.Parse(txtIndex.Text);
                    list.AddAt(index, value);
                }
                RefreshList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbRemovePosition.SelectedIndex == 0)
                list.RemoveFirst();
            else if (cbRemovePosition.SelectedIndex == 1)
                list.RemoveLast();
            else if (cbRemovePosition.SelectedIndex == 2)
            {
                int index = int.Parse(txtRemoveIndex.Text);
                list.RemoveAt(index);
            }
            RefreshList();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rbFindByValue.Checked)
            {
                int value = int.Parse(txtFind.Text);
                int index = list.FindByValue(value);
                MessageBox.Show(index == -1 ? "Not found" : $"Found at index {index}");
            }
            else
            {
                int index = int.Parse(txtFind.Text);
                int value = list.FindByIndex(index);
                MessageBox.Show($"Value: {value}");
            }
        }

        private void btnBuildList_Click(object sender, EventArgs e)
        {
            int[] values = txtInputList.Text
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            list = new DoublyLinkedList(values);
            RefreshList();
        }

        private void btnRemovePalindromes_Click(object sender, EventArgs e)
        {
            list.RemovePalindromes();
            RefreshList();
        }

        private void RefreshList()
        {
            lblList.Text = "List: " + list.ToString();
        }
        
        private void cbAddPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем поле индекса только если выбрана вставка по индексу
            bool showIndex = cbAddPosition.SelectedItem?.ToString() == "По индексу";
            txtIndex.Visible = showIndex;
            txtIndex.Enabled = showIndex;
        }

        private void cbRemovePosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Показываем поле индекса только если выбрано удаление по индексу
            bool showIndex = cbRemovePosition.SelectedItem?.ToString() == "По индексу";
            txtRemoveIndex.Visible = showIndex;
            txtRemoveIndex.Enabled = showIndex;
        }

    }
}
