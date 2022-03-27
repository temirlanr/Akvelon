namespace Fraction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fraction1 = new Fraction(1, 4);
            var fraction2 = new Fraction(2, 5);
            var fraction3 = new Fraction(5, 75);
            
            Console.WriteLine(fraction2.Equals(new Fraction(2, 5)));

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
        }
    }
}