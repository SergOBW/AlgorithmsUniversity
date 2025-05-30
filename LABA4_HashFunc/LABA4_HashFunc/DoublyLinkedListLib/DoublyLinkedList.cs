namespace LABA4_HashFunc.DoublyLinkedListLib
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Prev;
        public Node<T> Next;

        public Node(T value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public DoublyLinkedList() { }

        public DoublyLinkedList(T[] values)
        {
            foreach (var v in values)
                AddLast(v);
        }

        public DoublyLinkedList(DoublyLinkedList<T> other)
        {
            var current = other.head;
            while (current != null)
            {
                AddLast(current.Value);
                current = current.Next;
            }
        }

        ~DoublyLinkedList()
        {
            Clear();
        }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            if (head == null)
                head = tail = node;
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            if (tail == null)
                head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Count++;
        }

        public void AddAt(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (index == 0) AddFirst(value);
            else if (index == Count) AddLast(value);
            else
            {
                var current = GetNode(index);
                var node = new Node<T>(value)
                {
                    Prev = current.Prev,
                    Next = current
                };
                current.Prev.Next = node;
                current.Prev = node;
                Count++;
            }
        }

        public void RemoveFirst()
        {
            if (head == null) return;
            if (head == tail)
                head = tail = null;
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            Count--;
        }

        public void RemoveLast()
        {
            if (tail == null) return;
            if (head == tail)
                head = tail = null;
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            Count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            if (index == 0) RemoveFirst();
            else if (index == Count - 1) RemoveLast();
            else
            {
                var current = GetNode(index);
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                Count--;
            }
        }

        public T FindByIndex(int index)
        {
            return GetNode(index).Value;
        }

        public int FindByValue(T value)
        {
            var current = head;
            int index = 0;
            while (current != null)
            {
                if (Equals(current.Value, value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public T FindByValue(Func<T, bool> predicate)
        {
            var current = head;
            while (current != null)
            {
                if (predicate(current.Value))
                    return current.Value;
                current = current.Next;
            }
            return default;
        }

        public override string ToString()
        {
            var current = head;
            var result = "";
            while (current != null)
            {
                result += current.Value + " ";
                current = current.Next;
            }
            return result.Trim();
        }

        public string ToFormattedString()
        {
            return ToString();
        }

        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        private Node<T> GetNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current;
        }
    }
}
