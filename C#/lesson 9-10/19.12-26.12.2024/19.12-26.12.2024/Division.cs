namespace _19._12_26._12._2024;

public class Division : ICalculatorOperation
{

    public double Execute(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Невозможно поделить на нуль!");
        }


        return a / b;
    }

    /*public double Execute(double a, double b)
    {
      if (b != 0)
      {
        return a / b;
      }
      throw new DivideByZeroException();
    }*/

    public string Name => "Деление";

    /*public string Name
    {
      get { return "Деление"}
    };*/

};