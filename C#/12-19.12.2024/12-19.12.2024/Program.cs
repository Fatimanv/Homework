namespace LibraryManager
{
    class Program
    {
        static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в библиотеку!");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Показать все книги");
                Console.WriteLine("4. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        ShowBooks();
                        break;
                    case "4":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                books.Add(new Book(title, author, year));
                Console.WriteLine("Книга добавлена!\n");
            }
            else
            {
                Console.WriteLine("Некорректный год. Книга не добавлена.\n");
            }
        }

        static void RemoveBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Список книг пуст.\n");
                return;
            }

            ShowBooks();

            Console.Write("Введите индекс книги для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= books.Count)
            {
                books.RemoveAt(index - 1);
                Console.WriteLine("Книга удалена!\n");
            }
            else
            {
                Console.WriteLine("Некорректный индекс.\n");
            }
        }

        static void ShowBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Список книг пуст.\n");
                return;
            }

            Console.WriteLine("Список книг:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
            Console.WriteLine();
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"\"{Title}\" - {Author} ({Year})";
        }
    }
}
