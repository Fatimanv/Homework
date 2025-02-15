namespace _19._12_26._12._2024;

public class Multiplication : ICalculatorOperation
{
    public double Execute(double a, double b) => a * b;

    /*public double Execute(double a, double b)
    {
      return a * b;
    }*/
    public string Name => "Умножение";
  
    /*public string Name
    {
      get { return "Умножение";}
    };*/
};
