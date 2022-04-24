using System.Threading.Tasks;

namespace TraverseTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var node1 = new Tree<int>(1);
            var node2 = new Tree<int>(2);
            var node3 = new Tree<int>(3);
            var parent1 = new Tree<int>(4)
            {
                Right = node1,
                Left = node2
            };
            var parent2 = new Tree<int>(5)
            {
                Right = node3
            };
            var root = new Tree<int>(6)
            {
                Left = parent1,
                Right = parent2
            };

            Tree<int>.DoTree(root, (data) => Console.WriteLine(data));
        }
    }
}