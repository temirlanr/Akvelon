namespace Text_Editor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var editor = new TextEditor(50, 50);

            editor.InsertChar('f');
            editor.Print();
            Console.WriteLine();
            editor.InsertChar('c');
            editor.Print();
            Console.WriteLine();
            editor.InsertChar('k');
            editor.Print();
            Console.WriteLine();
            editor.MoveCursorTo(1, 2);
            editor.InsertChar('u');
            editor.Print();
            Console.WriteLine();
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine();
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine();
        }
    }
}