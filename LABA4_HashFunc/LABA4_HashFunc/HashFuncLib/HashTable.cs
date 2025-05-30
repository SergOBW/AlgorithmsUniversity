using LABA4_HashFunc.DoublyLinkedListLib;
namespace LABA4_HashFunc.HashFuncLib;

/*
 * Метод получает ключ — в твоём случае ISBN книги (int).

Хеш-функция вычисляет остаток от деления ISBN на размер таблицы (10).

Остаток — это индекс корзины, куда кладётся объект.

Например, ISBN = 1234567890, тогда индекс = 1234567890 % 10 = 0.
 */
public class HashTable
{
    private const int TableSize = 10;
    private DoublyLinkedList<Book>[] table;

    public HashTable()
    {
        table = new DoublyLinkedList<Book>[TableSize];
        for (int i = 0; i < TableSize; i++)
            table[i] = new DoublyLinkedList<Book>();
    }

    private int Hash(int key)
    {
        return key % TableSize;
    }

    public void Insert(Book book)
    {
        int index = Hash(book.ISBN);
        table[index].AddLast(book);
    }

    public Book Find(int isbn)
    {
        int index = Hash(isbn);
        return table[index].FindByValue(b => b.ISBN == isbn);
    }

    public string Display()
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < TableSize; i++)
        {
            sb.Append($"[{i}]: ");
            sb.AppendLine(table[i].ToFormattedString());
        }
        return sb.ToString();
    }
}
