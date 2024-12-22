abstract class Transport
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Тип: {Type}, Марка: {Brand}, Модель: {Model}, Год выпуска: {Year}, Максимальная скорость: {MaxSpeed} км/ч");
    }

    public abstract void Move();
}


class Car : Transport
{
    public string FuelType { get; set; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Тип топлива: {FuelType}");
    }

    public override void Move()
    {
        Console.WriteLine($"Автомобиль {Brand} {Model} едет по дороге со скоростью до {MaxSpeed} км/ч.");
    }
}
class Truck : Transport
{
    public double LoadCapacity { get; set; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Грузоподъемность: {LoadCapacity} тонн");
    }

    public override void Move()
    {
        Console.WriteLine($"Грузовик {Brand} {Model} перевозит груз.");
    }
}


class Bike : Transport
{
    public bool HasSidecar { get; set; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Наличие коляски: {(HasSidecar ? "Да" : "Нет")}");
    }

    public override void Move()
    {
        Console.WriteLine($"Мотоцикл {Brand} {Model} мчится по дороге.");
    }
}


class Bus : Transport
{
    public int PassengerCapacity { get; set; }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Пассажировместимость: {PassengerCapacity}");
    }

    public override void Move()
    {
        Console.WriteLine($"Автобус {Brand} {Model} перевозит пассажиров.");
    }
}

class Program
{
    static List<Transport> transportPark = new List<Transport>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить транспортное средство");
            Console.WriteLine("2. Показать все транспортные средства");
            Console.WriteLine("3. Запустить транспорт");
            Console.WriteLine("4. Удалить транспортное средство");
            Console.WriteLine("5. Фильтрация транспорта по типу");
            Console.WriteLine("6. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTransport();
                    break;
                case "2":
                    ShowAllTransports();
                    break;
                case "3":
                    StartTransport();
                    break;
                case "4":
                    RemoveTransport();
                    break;
                case "5":
                    FilterTransportByType();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }

    static void AddTransport()
    {
        Console.WriteLine("Выберите тип транспорта: 1. Автомобиль, 2. Грузовик, 3. Мотоцикл, 4. Автобус");
        string typeChoice = Console.ReadLine();
        Transport transport = null;

        Console.Write("Введите марку: ");
        string brand = Console.ReadLine();
        Console.Write("Введите модель: ");
        string model = Console.ReadLine();
        Console.Write("Введите год выпуска: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Введите максимальную скорость: ");
        int maxSpeed = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                transport = new Car
                {
                    Type = "Автомобиль",
                    Brand = brand,
                    Model = model,
                    Year = year,
                    MaxSpeed = maxSpeed,
                    FuelType = ReadString("Введите тип топлива (бензин, дизель, электро): ")
                };
                break;
            case "2":
                transport = new Truck
                {
                    Type = "Грузовик",
                    Brand = brand,
                    Model = model,
                    Year = year,
                    MaxSpeed = maxSpeed,
                    LoadCapacity = ReadDouble("Введите грузоподъемность (в тоннах): ")
                };
                break;
            case "3":
                transport = new Bike
                {
                    Type = "Мотоцикл",
                    Brand = brand,
                    Model = model,
                    Year = year,
                    MaxSpeed = maxSpeed,
                    HasSidecar = ReadBool("Есть ли коляска (да/нет): ")
                };
                break;
            case "4":
                transport = new Bus
                {
                    Type = "Автобус",
                    Brand = brand,
                    Model = model,
                    Year = year,
                    MaxSpeed = maxSpeed,
                    PassengerCapacity = ReadInt("Введите пассажировместимость: ")
                };
                break;
            default:
                Console.WriteLine("Неверный выбор типа транспорта.");
                return;
        }

        transportPark.Add(transport);
        Console.WriteLine("Транспорт добавлен.");
    }

    static void ShowAllTransports()
    {
        if (transportPark.Count == 0)
        {
            Console.WriteLine("Список транспортных средств пуст.");
            return;
        }

        for (int i = 0; i < transportPark.Count; i++)
        {
            Console.WriteLine($"#{i + 1}");
            transportPark[i].ShowInfo();
            Console.WriteLine();
        }
    }

    static void StartTransport()
    {
        ShowAllTransports();
        Console.Write("Введите номер транспорта для запуска: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < transportPark.Count)
        {
            transportPark[index].Move();
        }
        else
        {
            Console.WriteLine("Неверный номер.");
        }
    }

    static void RemoveTransport()
    {
        ShowAllTransports();
        Console.Write("Введите номер транспорта для удаления: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < transportPark.Count)
        {
            transportPark.RemoveAt(index);
            Console.WriteLine("Транспорт удалён.");
        }
        else
        {
            Console.WriteLine("Неверный номер.");
        }
    }

    static void FilterTransportByType()
    {
        Console.WriteLine("Введите тип транспорта для фильтрации (Автомобиль, Грузовик, Мотоцикл, Автобус): ");
        string type = Console.ReadLine();

        foreach (var transport in transportPark)
        {
            if (transport.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                transport.ShowInfo();
                Console.WriteLine();
            }
        }
    }

    static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }

    static bool ReadBool(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        return input.Equals("да", StringComparison.OrdinalIgnoreCase);
    }
}
