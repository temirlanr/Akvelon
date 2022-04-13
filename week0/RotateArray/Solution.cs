using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            int[] clone = (int[])nums.Clone();
            var len = nums.Length;

            if (len == 1 || len == 0)
            {
                return;
            }

            k = k % len;

            for (int i = 0; i < k; i++)
            {
                nums[i] = clone[len - k + i];
            }

            for (int i = k; i < len; i++)
            {
                nums[i] = clone[i - k];
            }
        }
    }
}
