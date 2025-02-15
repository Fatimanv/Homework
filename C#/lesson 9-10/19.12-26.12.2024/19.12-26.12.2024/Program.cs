

namespace _19._12_26._12._2024;

class Program
{
    static List<ICalculatorOperation> operations = new List<ICalculatorOperation>
    {
        new Addition(),
        new Subtraction(),
        new Multiplication(),
        new Division(),
    }; //нужно для того чтобы мы с легкостью могли добавлять новые операцию, я планировала делать с помощью
    // свичей, но потом мне бы вручную надо было бы писать много чего

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Доступные операции:");
            for (int i = 0; i < operations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {operations[i].Name}");
            }

            Console.WriteLine("0. Выход");
            Console.Write("Выберите операцию: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > operations.Count)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                continue;
            }

            if (choice == 0) break;

            Console.Write("Введите первое число: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Ошибка: некорректный ввод. Введите число.");
                continue;
            }

            Console.Write("Введите второе число: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Ошибка: некорректный ввод. Введите число.");
                continue;
            }

            try
            {
                double result = operations[choice - 1].Execute(num1, num2);
                Console.WriteLine($"Результат: {result}");
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

}