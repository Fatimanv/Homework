namespace _19._12_26._12._2024;

public class Subtraction : ICalculatorOperation
{
    public double Execute(double a, double b) => a - b;

    /*public double Execute(double a, double b)
    {
      return a - b;
    }*/

    public string Name => "Вычитание";

    /*public string Name
    {
      get { return "Сложение"; }
    }*/


};