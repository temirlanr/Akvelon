using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthNode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode node = head;

            if (node.next == null)
            {
                return null;
            }

            int len = 1;

            while (node.next != null)
            {
                len += 1;
                node = node.next;
            }

            node = head;

            if (len == n)
            {
                node = node.next;
                head.next = null;
                return node;
            }

            for (int i = 0; i < len - n - 1; i++)
            {
                node = node.next;
            }

            node.next = node.next.next;

            return head;
        }
    }
}
