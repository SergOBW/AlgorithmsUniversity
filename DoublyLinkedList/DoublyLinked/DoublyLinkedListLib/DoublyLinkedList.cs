namespace DoublyLinked.DoublyLinkedListLib
{
    public class Node
    {
        public int Data;
        public Node Prev;
        public Node Next;

        public Node(int data)
        {
            Data = data;
        }
    }

    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public DoublyLinkedList() { }

        public DoublyLinkedList(int[] values)
        {
            foreach (var v in values)
                AddLast(v);
        }

        public DoublyLinkedList(DoublyLinkedList other)
        {
            var current = other.head;
            while (current != null)
            {
                AddLast(current.Data);
                current = current.Next;
            }
        }

        ~DoublyLinkedList()
        {
            Clear();
        }

        public void AddFirst(int data)
        {
            var node = new Node(data);
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

        public void AddLast(int data)
        {
            var node = new Node(data);
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

        public void AddAt(int index, int data)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (index == 0) AddFirst(data);
            else if (index == Count) AddLast(data);
            else
            {
                var current = GetNode(index);
                var node = new Node(data)
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

        public int FindByIndex(int index)
        {
            return GetNode(index).Data;
        }

        public int FindByValue(int value)
        {
            var current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data == value)
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public override string ToString()
        {
            var current = head;
            var result = "";
            while (current != null)
            {
                result += current.Data + " ";
                current = current.Next;
            }
            return result.Trim();
        }

        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        public void RemovePalindromes()
        {
            var current = head;
            int index = 0;
            while (current != null)
            {
                var next = current.Next;
                if (IsPalindrome(current.Data))
                    RemoveAt(index);
                else
                    index++;
                current = next;
            }
        }

        /*
         * Палиндром — это число, слово или фраза, которое читается одинаково слева направо и справа налево.
         */
        private bool IsPalindrome(int number)
        {
            var s = number.ToString();
            var reversed = new string(s.Reverse().ToArray());
            return s == reversed;
        }

        private Node GetNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current;
        }
    }
}
