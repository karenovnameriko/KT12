namespace Kt12_3;

class Program
{
    interface IFactory<T>
    {
        T Create();
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

    class RandomNumberFactory : IFactory<int>
    {
        private Random random = new Random();

        public int Create()
        {
            return random.Next(1, 101); 
        }
    }

    class PersonFactory : IFactory<Person>
    {
        public Person Create()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            return new Person(name, age);
        }
    }

    static T[] CreateArray<T>(IFactory<T> factory, int n)
    {
        T[] array = new T[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = factory.Create();
        }
        return array;
    }


    static void Main(string[] args)
    {
        IFactory<int> numberFactory = new RandomNumberFactory();
        int[] numbers = CreateArray(numberFactory, 5);

        Console.WriteLine("Random numbers:");
        foreach (var num in numbers)
            Console.WriteLine(num);

        IFactory<Person> personFactory = new PersonFactory();
        Person[] people = CreateArray(personFactory, 2);

        Console.WriteLine("\nPeople:");
        foreach (var person in people)
            Console.WriteLine(person);
        Console.ReadKey();
    }
}

