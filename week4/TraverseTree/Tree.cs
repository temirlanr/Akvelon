using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraverseTree
{
    public class Tree<T>
    {
        public Tree<T> Left;
        public Tree<T> Right;
        public T Data { get; private set; }

        public Tree(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public static void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;

            Task[] tasks = 
            {
                Task.Run(() => DoTree(tree.Left, action)),
                Task.Run(() => DoTree(tree.Right, action)),
                Task.Run(() => action(tree.Data))
            };

            Task.WaitAll(tasks);
        }
    }
}
