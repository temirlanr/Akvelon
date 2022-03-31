using System;
using Text_Editor;
using Xunit;

namespace TextEditorTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertChar_Many_as_Equal_a()
        {
            var editor = new TextEditor(10, 20);

            for(int i = 0; i < 21; i++)
            {
                editor.InsertChar('a');
            }

            Assert.Equal('a', editor.GetChar(2, 1));
        }
    }
}