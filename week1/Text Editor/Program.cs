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
            editor.InsertChar('l');
            editor.Print();
            Console.WriteLine(" <= InsertChar(l)");
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
            editor.MoveCursorTo(1, 4);
            Console.WriteLine(" <= MoveCursorTo(1, 4), DeleteChar()");
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine(" <= DeleteChar()");
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine(" <= DeleteChar()");
            editor.DeleteChar();
            editor.Print();
            Console.WriteLine(" <= DeleteChar()");

            for (int i=0; i<50; i++)
            {
                editor.InsertChar('a');
            }

            editor.InsertChar('a');
            editor.InsertChar('a');

            Console.WriteLine(editor.GetChar(1, 50));
            Console.WriteLine(editor.GetChar(2, 1));

            editor.DeleteChar();
            editor.DeleteChar();

            Console.WriteLine(editor.GetChar(2, 1));
            Console.WriteLine(editor.GetChar(2, 2));
        }
    }
}