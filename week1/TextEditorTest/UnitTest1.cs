using System;
using Text_Editor;
using Xunit;

namespace TextEditorTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertChar_a_Equal_a()
        {
            var editor = new TextEditor(10, 20);

            for(int i = 0; i < 21; i++)
            {
                editor.InsertChar('a');
            }

            Assert.Equal('a', editor.GetChar(2, 1));
        }

        [Fact]
        public void DeleteChar_Equal_default()
        {
            var editor = new TextEditor(10, 10);

            editor.DeleteChar(); // Nothing should happen

            Assert.Equal(default, editor.GetChar(1, 1));
        }

        [Fact]
        public void InsertCharUndo_Equal_default()
        {
            var editor = new TextEditor(10, 10);

            editor.InsertChar('a');
            editor.Undo();

            Assert.Equal(default, editor.GetChar(1, 1));
        }

        [Fact]
        public void InsertCharRedo_Equal_value()
        {
            var editor = new TextEditor(10, 10);

            editor.InsertChar('a');
            editor.Redo();

            Assert.Equal('a', editor.GetChar(1, 1));
        }

        [Fact]
        public void UndoRedo_Equal_value()
        {
            var editor = new TextEditor(10, 10);

            editor.InsertChar('a');
            editor.Undo();
            editor.Redo();

            Assert.Equal('a', editor.GetChar(1, 1));
        }
    }
}