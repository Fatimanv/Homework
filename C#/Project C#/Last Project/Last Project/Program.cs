using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Car
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Make { get; set; }
    public string Model { get; set; }
    public DateTime Year { get; set; }
}

class Showroom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Car> Cars { get; set; } = new();
    public int CarCapacity { get; set; }
    public int CarCount => Cars.Count;
    public int SalesCount { get; set; }
}

class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowroomId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowroomId { get; set; }
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static List<Showroom> Showrooms = new();
    static List<User> Users = new();
    static List<Sale> Sales = new();

    static void Main(string[] args)
    {
        LoadData();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Login\n2. Register\n3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        SaveData();
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine("Login successful.");
            UserMenu(user);
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
        }
    }

    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Users.Add(new User { Username = username, Password = password });
        Console.WriteLine("Registration successful.");
    }

    static void UserMenu(User user)
    {
        bool loggedIn = true;

        while (loggedIn)
        {
            Console.WriteLine("1. Create Showroom\n2. View Sales Statistics\n3. Logout");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateShowroom(user);
                    break;
                case "2":
                    ViewSalesStatistics(user);
                    break;
                case "3":
                    loggedIn = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateShowroom(User user)
    {
        Console.Write("Enter showroom name: ");
        string name = Console.ReadLine();
        Console.Write("Enter car capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        var showroom = new Showroom { Name = name, CarCapacity = capacity };
        Showrooms.Add(showroom);

        user.ShowroomId = showroom.Id;
        Console.WriteLine("Showroom created successfully.");
    }

    static void ViewSalesStatistics(User user)
    {
        var showroom = Showrooms.FirstOrDefault(s => s.Id == user.ShowroomId);

        if (showroom == null)
        {
            Console.WriteLine("No showroom found.");
            return;
        }

        Console.WriteLine("Select period: 1. Day 2. Week 3. Month 4. Year");
        string periodChoice = Console.ReadLine();

        DateTime startDate = DateTime.Now;
        switch (periodChoice)
        {
            case "1":
                startDate = DateTime.Now.Date;
                break;
            case "2":
                startDate = DateTime.Now.AddDays(-7);
                break;
            case "3":
                startDate = DateTime.Now.AddMonths(-1);
                break;
            case "4":
                startDate = DateTime.Now.AddYears(-1);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        var sales = Sales.Where(s => s.ShowroomId == showroom.Id && s.SaleDate >= startDate);
        Console.WriteLine($"Sales statistics for {showroom.Name}:");
        foreach (var sale in sales)
        {
            Console.WriteLine($"Car ID: {sale.CarId}, User ID: {sale.UserId}, Sale Date: {sale.SaleDate}, Price: {sale.Price:C}");
        }
    }

  
    static void LoadData()
    {
        if (File.Exists("showrooms.json"))
            Showrooms = JsonSerializer.Deserialize<List<Showroom>>(File.ReadAllText("showrooms.json")) ?? new();
        if (File.Exists("users.json"))
            Users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("users.json")) ?? new();
        if (File.Exists("sales.json"))
            Sales = JsonSerializer.Deserialize<List<Sale>>(File.ReadAllText("sales.json")) ?? new();
    }

    static void SaveData()
    {
        File.WriteAllText("showrooms.json", JsonSerializer.Serialize(Showrooms));
        File.WriteAllText("users.json", JsonSerializer.Serialize(Users));
        File.WriteAllText("sales.json", JsonSerializer.Serialize(Sales));
    }
}
