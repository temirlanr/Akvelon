using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            if (nums.Length % 2 == 0)
            {
                throw new ArgumentException("Each element in the array appears twice except for one element which appears only once.");
            }

            var data = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (data.ContainsKey(nums[i]))
                {
                    data[nums[i]] = data[nums[i]] + 1;
                }
                else
                {
                    data[nums[i]] = 1;
                }
            }

            foreach (KeyValuePair<int, int> kvp in data)
            {
                if (kvp.Value == 1)
                {
                    return kvp.Key;
                }
            }

            return 0;
        }
    }
}
