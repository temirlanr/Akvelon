using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    public interface ICommand
    {
        void Undo();
        void Execute();
    }
}
