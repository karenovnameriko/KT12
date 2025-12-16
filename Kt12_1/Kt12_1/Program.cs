namespace KT12_1;

class Program
{
    interface IList<T>
    {
        void Add(T item);
        void Remove(T item);
        T Get(int index);
        void Set(int index, T item);
        int Count { get; }
    }

    class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int count;

        public ArrayList(int capacity = 4)
        {
            items = new T[capacity];
            count = 0;
        }

        public int Count => count;

        public void Add(T item)
        {
            if (count == items.Length)
            {
                // увеличиваем массив вдвое
                T[] newItems = new T[items.Length * 2];
                Array.Copy(items, newItems, items.Length);
                items = newItems;
            }
            items[count++] = item;
        }

        public void Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return;

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            return items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            items[index] = item;
        }
    }
    class LinkedList<T> : IList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node(T data) { Data = data; Next = null; }
        }

        private Node head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public int Count => count;

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public void Remove(T item)
        {
            if (head == null) return;

            if (Equals(head.Data, item))
            {
                head = head.Next;
                count--;
                return;
            }

            Node current = head;
            while (current.Next != null && !Equals(current.Next.Data, item))
                current = current.Next;

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                count--;
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            current.Data = item;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString() => $"{Name}, Age {Age}";
    }


    static void Main(string[] args)
    {
        // ArrayList<int>
        IList<int> arrayList = new ArrayList<int>();
        arrayList.Add(10);
        arrayList.Add(20);
        arrayList.Add(30);
        for (int i = 0; i < arrayList.Count; i++)
            Console.WriteLine(arrayList.Get(i));

        // LinkedList<string>
        IList<string> linkedList = new LinkedList<string>();
        linkedList.Add("Hello");
        linkedList.Add("World");
        linkedList.Add("!");
        for (int i = 0; i < linkedList.Count; i++)
            Console.WriteLine(linkedList.Get(i));

        // ArrayList<Person>
        IList<Person> people = new ArrayList<Person>();
        people.Add(new Person("Anna", 20));
        people.Add(new Person("Bob", 25));
        for (int i = 0; i < people.Count; i++)
            Console.WriteLine(people.Get(i));
    }
}

