using System;

namespace RotateArray{
    public class Program {
        public static int[] Rotate(int[] nums, int k) {
            var len = nums.Length;
            var temp = new int[len];
            
            int index = 0;
            for(int i=len-k; i<len; i++){
                temp[index] = nums[i];
                index = index + 1;
            }
            
            for(int j=0; j<len-k; j++){
                temp[index] = nums[j];
                index = index + 1;
            }
            
            return temp;
        }

        public static void Main(string[] args){
            var array = new int[] {1,2,3,4,5,6,7};
            array = Rotate(array, 3);

            for(int i=0; i<array.Length; i++){
                Console.WriteLine(array[i]);
            }
        }
    }
}

