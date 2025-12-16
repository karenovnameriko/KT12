namespace KT12_2;

class Program
{
    interface IComparer<T>
    {
        int Compare(T x, T y);
    }

    class Book
    {
        public string Title { get; set; }
        public double Price { get; set; }

        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public override string ToString() => $"{Title}, ${Price}";
    }

    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null) return y == null ? 0 : -1;
            if (y == null) return 1;
            return x.Length.CompareTo(y.Length);
        }
    }

    class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null) return y == null ? 0 : -1;
            if (y == null) return 1;
            return x.Price.CompareTo(y.Price);
        }
    }

    static void SortArray<T>(T[] array, IComparer<T> comparer)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[i], array[j]) > 0)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }


    static void Main(string[] args)
    {
        string[] words = { "apple", "banana", "kiwi", "grape" };
        Console.WriteLine("Before sorting strings:");
        Console.WriteLine(string.Join(", ", words));

        SortArray(words, new StringComparer());
        Console.WriteLine("After sorting strings by length:");
        Console.WriteLine(string.Join(", ", words));

        Book[] books = {
            new Book("C# in Depth", 40),
            new Book("Introduction to Algorithms", 80),
            new Book("Clean Code", 50)
        };
        Console.WriteLine("\nBefore sorting books:");
        foreach (var book in books) Console.WriteLine(book);

        SortArray(books, new BookComparer());
        Console.WriteLine("\nAfter sorting books by price:");
        foreach (var book in books) Console.WriteLine(book);
    }
}

