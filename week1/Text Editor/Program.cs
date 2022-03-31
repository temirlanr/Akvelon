namespace Text_Editor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var editor = new TextEditor(50, 50);

            editor.InsertChar('h');
            editor.Print();
            Console.WriteLine(" <= InsertChar(h)");
            editor.InsertChar('l');
            editor.Print();
            Console.WriteLine(" <= InsertChar(l)");
            editor.Undo();
            editor.Print();
            Console.WriteLine(" <= Undo()");
            editor.Redo();
            editor.Print();
            Console.WriteLine(" <= Redo()");
            editor.InsertChar('l');
            editor.Print();
            Console.WriteLine(" <= InsertChar(l)");
            editor.InsertChar('o');
            editor.Print();
            Console.WriteLine(" <= InsertChar(o)");
            editor.MoveCursorTo(1, 2);
            editor.InsertChar('e');
            editor.Print();
            Console.WriteLine(" <= MoveCursorTo(1, 2), InsertChar(e)");
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine(" <= DeleteChar()");
            editor.Undo();
            editor.Print();
            Console.WriteLine(" <= Undo()");
            editor.Redo();
            editor.Print();
            Console.WriteLine(" <= Redo()");
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine(" <= DeleteChar()");
        }
    }
}