using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    public class TextEditor
    {
        private int _row;
        private int _col;
        private int _maxRows;
        private int _maxCols;
        private char[,] _text;
        private Stack<ICommand> _commandHistory;
        private Stack<ICommand> _undoneCommands;

        public TextEditor(int maxRows, int maxCols)
        {
            _maxRows = maxRows;
            _maxCols = maxCols;
            _row = 1;
            _col = 1;
            _text = new char[maxRows, maxCols];
            _commandHistory = new Stack<ICommand>();
            _undoneCommands = new Stack<ICommand>();
        }

        public void MoveCursorTo(int row, int col)
        {
            var command = new MoveCursorClass(this, row, col);
            command.Execute();
            _commandHistory.Push(command);
        }

        public void InsertChar(char c)
        {
            var command = new InsertCharClass(this, c);
            command.Execute();
            _commandHistory.Push(command);
        }

        public void DeleteChar()
        {
            var command = new DeleteCharClass(this);
            command.Execute();
            _commandHistory.Push(command);
        }

        public void Undo()
        {
            if(_commandHistory.Count == 0)
            {
                return;
            }

            var commandToUndo = _commandHistory.Pop();
            _undoneCommands.Push(commandToUndo);
            commandToUndo.Undo();
        }

        public void Redo()
        {
            if(_undoneCommands.Count == 0)
            {
                return;
            }

            var commandToRedo = _undoneCommands.Pop();
            commandToRedo.Execute();
            _commandHistory.Push(commandToRedo);
        }

        public void Print()
        {            
            for(int i=0; i<_text.GetLength(0); i++)
            {
                for(int j=0; j<_text.GetLength(1); j++)
                {
                    Console.Write(_text[i, j]);
                }
            }
        }

        public char GetChar(int row, int col)
        {
            return _text[row-1, col-1];
        }

        private void RotateLeft(int initR, int initC)
        {
            for (int i = initR - 1; i < _maxRows; i++)
            {
                if (i != initR - 1)
                {
                    for (int j = 0; j < _maxCols; j++)
                    {
                        if (j == _maxCols - 1 && i < _maxRows - 1)
                        {
                            _text[i, j] = _text[i + 1, 0];
                        }
                        else if (i == _maxRows-1 && j == _maxCols-1)
                        {
                            _text[i, j] = default;
                        }
                        else
                        {
                            _text[i, j] = _text[i, j + 1];
                        }
                    }
                }
                else
                {
                    for (int j = initC-1; j < _maxCols; j++)
                    {
                        if (j == _maxCols - 1 && i < _maxRows - 1)
                        {
                            _text[i, j] = _text[i + 1, 0];
                        }
                        else if (i == _maxRows - 1 && j == _maxCols - 1)
                        {
                            _text[i, j] = default;
                        }
                        else
                        {
                            _text[i, j] = _text[i, j + 1];
                        }
                    }
                }
            }
        }

        private void RotateRight(int initR, int initC)
        {
            for (int i = _maxRows - 1; i >= initR - 1; i--)
            {
                if (i != initR - 1)
                {
                    for (int j = _maxCols - 1; j >= 0; j--)
                    {
                        if (j == 0 && i >= 1)
                        {
                            _text[i, j] = _text[i - 1, _maxCols - 1];
                        }
                        else if (i == 0 && j == 0)
                        {
                            _text[i, j] = default;
                        }
                        else
                        {
                            _text[i, j] = _text[i, j - 1];
                        }
                    }
                }
                else
                {
                    for (int j = _maxCols - 1; j >= initC-1; j--)
                    {
                        if (j == 0 && i >= 1)
                        {
                            _text[i, j] = _text[i - 1, _maxCols - 1];
                        }
                        else if (i == 0 && j == 0)
                        {
                            _text[i, j] = default;
                        }
                        else
                        {
                            _text[i, j] = _text[i, j - 1];
                        }
                    }
                }
            }
        }

        private class MoveCursorClass : ICommand
        {
            private TextEditor editor;
            private int r;
            private int c;
            private int previousR;
            private int previousC;
            private bool executed = false;

            public MoveCursorClass(TextEditor editor, int row, int col)
            {
                this.editor = editor;
                r = row;
                c = col;
            }

            public void Execute()
            {
                previousR = editor._row;
                previousC = editor._col;
                editor._row = r;
                editor._col = c;
                executed = true;
            }

            public void Undo()
            {
                if(!executed)
                {
                    return;
                }

                editor._row = previousR;
                editor._col = previousC;
            }
        }

        private class InsertCharClass : ICommand
        {
            private TextEditor editor;
            private char c;
            private int previousR;
            private int previousC;
            private char[,] previousText;
            private bool executed = false;

            public InsertCharClass(TextEditor editor, char c)
            {
                this.editor = editor;
                this.c = c;
                previousR = editor._row;
                previousC = editor._col;
                previousText = editor._text;
            }

            public void Execute()
            {
                editor.RotateRight(editor._row, editor._col);

                editor._text[editor._row - 1, editor._col - 1] = c;

                if (editor._col < editor._maxCols)
                {
                    editor._col = editor._col + 1;
                }
                else
                {
                    editor._col = 2;
                    editor._row = editor._row + 1;
                }
                
                executed = true;
            }

            public void Undo()
            {
                if (!executed)
                {
                    return;
                }

                editor._text = previousText;
                editor._row = previousR;
                editor._col = previousC;
            }
        }

        private class DeleteCharClass : ICommand
        {
            private TextEditor editor;
            private int previousR;
            private int previousC;
            private char[,] previousText;
            private bool executed = false;

            public DeleteCharClass(TextEditor editor)
            {
                this.editor = editor;
                previousR = editor._row;
                previousC = editor._col;
                previousText = editor._text;
            }

            public void Execute()
            {
                if (editor._row-1 == 0 && editor._col-1 == 0)
                {
                    return;
                }

                editor._text[editor._row - 1, editor._col - 2] = default;

                editor.RotateLeft(editor._row, editor._col-1);

                if (editor._col-1 == 0)
                {
                    editor._row = editor._row - 1;
                    editor._col = editor._maxCols - 1;
                }
                else
                {
                    editor._col = editor._col - 1;
                }

                executed = true;
            }

            public void Undo()
            {
                if (!executed)
                {
                    return;
                }

                editor._text = previousText;
                editor._row = previousR;
                editor._col = previousC;
            }
        }
    }
}
