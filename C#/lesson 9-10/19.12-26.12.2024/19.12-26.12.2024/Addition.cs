namespace _19._12_26._12._2024;

public class Addition : ICalculatorOperation
{
    public double Execute(double a, double b) => a + b;
  
    /*public double Execute(double a, double b)
    {
      return a + b;
    }*/ 
    public string Name => "Сложение"; //возвращает слово "Умножение" каждый раз когда вызывается 
  
    /*public string Name
    {
      get { return "Сложение"; }
    }*/ 
  
    // можно считать что это разввернутый вид вышенаписанного
  
   
};