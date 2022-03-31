namespace FractionNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fraction1 = new Fraction(1, 4);
            var fraction2 = new Fraction(2, 5);
            var fraction3 = new Fraction(5, 75);
            var fraction4 = new Fraction(0, 7);

            Console.WriteLine(fraction2.Equals(new Fraction(2, 5)));

            Console.WriteLine("fraction3 before addition:");
            fraction3.Print();
            fraction3.Add(fraction4);
            Console.WriteLine("fraction3 after addition:");
            fraction3.Print();

            Console.WriteLine("fraction1 before subtraction:");
            fraction1.Print();
            fraction1.Subtract(fraction2);
            Console.WriteLine("fraction1 after subtraction:");
            fraction1.Print();

            Console.WriteLine("fraction2 before multiplication:");
            fraction2.Print();
            fraction2.Multiply(fraction3);
            Console.WriteLine("fraction2 after multiplication:");
            fraction2.Print();

            Console.WriteLine("fraction4 before division:");
            fraction4.Print();
            fraction4.Divide(fraction1);
            Console.WriteLine("fraction4 after division:");
            fraction4.Print();

            Console.WriteLine(fraction3.ToDouble());

            Console.WriteLine("Checking if fraction can be divided by 0:");
            
            try
            {
                fraction1.Divide(fraction4);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            fraction1.Print();

            var temp = (double)fraction1;

            Console.WriteLine(temp);
        }
    }
}