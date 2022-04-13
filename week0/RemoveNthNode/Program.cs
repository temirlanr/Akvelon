namespace RemoveNthNode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListNode[] linkedList = new ListNode[5]
            {
                new ListNode(),
                new ListNode(),
                new ListNode(),
                new ListNode(),
                new ListNode()
            };
            
            for(int i = 0; i < linkedList.Length; i++)
            {
                if(i == 4)
                {
                    linkedList[i] = new ListNode(i + 1);
                }
                else
                {
                    linkedList[i] = new ListNode(i + 1, linkedList[i + 1]);
                }
            }

            Solution solution = new Solution();

            ListNode node = linkedList[0];
            solution.RemoveNthFromEnd(node, 2);

            while(node.next != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }
    }
}