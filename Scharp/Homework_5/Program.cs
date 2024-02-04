
namespace Homework_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Доработайте программу калькулятор реализовав выбор действий и вывод результатов 
            //на экран в цикле так чтобы калькулятор мог работать до тех пор пока пользователь 
            //не нажмет отмена или введёт пустую строку.

            Calculator calculator = new Calculator();
            calculator.Result += Calculator_Result;
            calculator.Add(10);
            calculator.Add(35);
            calculator.Div(3);
            calculator.Mult(2);

            Console.WriteLine();


            calculator.Cancel();    
            calculator.Cancel();    
            calculator.Cancel();    
            calculator.Cancel();    

            calculator.Result -= Calculator_Result;
            
        }

        private static void Calculator_Result(object? sender, CalculatorArgs e)
        {
            Console.Write($"{e.answer}  ");
        }
    }
}
