using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates
{
    // Definition for singly-linked list.
    public class ListNode 
    {    
        public int val;
        public ListNode next;
        
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            Dictionary<int, int> data = new Dictionary<int, int>();
            var temp = head;
            ListNode listNode;

            while(temp.next != null)
            {
                if (data.ContainsKey(temp.val))
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    data[temp.val] = 1;
                    temp = temp.next;
                }
            }

            return head;
        }
    }
}
