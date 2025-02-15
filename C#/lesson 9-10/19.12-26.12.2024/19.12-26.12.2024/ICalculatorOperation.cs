namespace _19._12_26._12._2024;

    public interface ICalculatorOperation
    {
        double Execute(double a, double b);
        string Name { get; } //получаем операцию не меняя его вручную 
    }
