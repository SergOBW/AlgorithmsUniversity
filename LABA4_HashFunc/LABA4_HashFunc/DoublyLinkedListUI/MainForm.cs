using LABA4_HashFunc.HashFuncLib;

namespace LabA4_HashFunc.UI
{
    public partial class MainForm : Form
    {
        private HashTable hashTable = new HashTable();
        private Random rand = new Random();

        private string[] sampleTitles = {
            "War and Peace", "1984", "Brave New World", "Catch-22",
            "The Hobbit", "Fahrenheit 451", "Moby Dick", "The Odyssey",
            "Hamlet", "The Great Gatsby"
        };

        private string[] sampleAuthors = {
            "Tolstoy", "Orwell", "Huxley", "Heller",
            "Tolkien", "Bradbury", "Melville", "Homer",
            "Shakespeare", "Fitzgerald"
        };

        public MainForm()
        {
            InitializeComponent();
            hashTable = new HashTable();
        }
        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            hashTable = new HashTable(); // очистка

            HashSet<int> usedISBN = new HashSet<int>();

            for (int i = 0; i < 20; i++)
            {
                int isbn;
                do
                {
                    isbn = rand.Next(1_000_000, 10_000_000);
                } while (usedISBN.Contains(isbn));
                usedISBN.Add(isbn);

                var book = new Book
                {
                    ISBN = isbn,
                    Title = sampleTitles[rand.Next(sampleTitles.Length)],
                    Author = sampleAuthors[rand.Next(sampleAuthors.Length)]
                };

                hashTable.Insert(book);
            }

            txtOutput.Text = "Сгенерировано и добавлено 20 книг.\r\nНажмите 'Показать таблицу' для просмотра.";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtISBN.Text, out int isbn))
            {
                ShowMessage("Введите корректный ISBN (число).");
                return;
            }
            var title = txtTitle.Text.Trim();
            var author = txtAuthor.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                ShowMessage("Введите название книги и автора.");
                return;
            }

            var book = new Book
            {
                ISBN = isbn,
                Title = title,
                Author = author
            };

            hashTable.Insert(book);
            ShowMessage($"Книга добавлена: {book}");
            ClearInputs();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearchISBN.Text, out int isbn))
            {
                ShowMessage("Введите корректный ISBN для поиска.");
                return;
            }

            var found = hashTable.Find(isbn);
            if (found != null)
                ShowMessage($"Найдена книга: {found}");
            else
                ShowMessage($"Книга с ISBN {isbn} не найдена.");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            txtOutput.Text = hashTable.Display();
        }

        private void ShowMessage(string msg)
        {
            txtOutput.Text = msg;
        }

        private void ClearInputs()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
        }
    }
}
