namespace Text_Editor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var editor = new TextEditor(50, 50);

            editor.InsertChar('h');
            editor.Print();
            Console.WriteLine();
            editor.InsertChar('l');
            editor.Print();
            Console.WriteLine();
            editor.InsertChar('l');
            editor.Print();
            Console.WriteLine();
            editor.InsertChar('o');
            editor.Print();
            Console.WriteLine();
            editor.MoveCursorTo(1, 2);
            editor.InsertChar('e');
            editor.Print();
            Console.WriteLine();
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine();
            editor.Undo();
            editor.Print();
            Console.WriteLine();
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine();
        }
    }
}