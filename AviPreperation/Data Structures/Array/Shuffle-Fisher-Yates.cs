using System;

public class FisherYatesShuffel {
    private int[] original;
    private int[] array;
    Random rand = new Random();
    
    private int RandomGen(int min, int max){
        return rand.Next(min, max);
    }
    
    private void SwapEle(int i, int j){
        int temp = array[j];
        array[j] = array[i];
        array[i] = temp;
    }
    
    public Solution(int[] nums) {
        array = nums;
        original = (int[])nums.Clone();
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
        array = original;
        original = (int[])original.Clone();
       return original; 
    }
    
    /** Returns a random shuffling of the array. */
    public int[] Shuffle() {
        for(int i=0; i<array.Length; i++){
            SwapEle(i, RandomGen(i, array.Length));
        }
        return array;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */