/*
You are given a list of songs where the ith song has a duration of time[i] seconds.

Return the number of pairs of songs for which their total duration in seconds is divisible by 60. Formally, we want the number of indices i, j such that i < j with (time[i] + time[j]) % 60 == 0.
*/
//best and quickest way for (On) complexity
public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        
        //init the int array to keep track of remainder values and the count
        int[] dict = new int[500];
        int count = 0;
        
        //loop through each time in time array
        foreach(int tim in time)
        {
            // first I get the remainder of the current time
            int rem = tim % 60;
            // then I check if in the array if it contains a pair that would be mod 60 and if there is I add one to the count
            count += rem != 0 ? dict[60 - rem] : dict[0];
            //I then add the current mod to the array
            dict[rem] = dict[rem] +1;
        }
        //return the count
        return count;
    }
}


//Another solution for (On2) complexity

public class Solution1 {
    public int NumPairsDivisibleBy60(int[] time) {
        
        //number to return for pairs
        int divisibleNum = 0;
        //Loop through the ist and see if any of the combination is divisible  by 60
        for(int i = 0; i<time.GetLength(0); i++)
        {
            //Make sure that j is equal to i so that there is no duplications
            for(int j = i; j<time.GetLength(0); j++)
            {   //if it is not a duplication check if divisible by 60 and if so and to return number
                if(i != j)
                {
                    if(((time[i]+time[j]) % 60) == 0)
                    {
                        divisibleNum += 1;
                    }
                }
            }
        }
        
        return divisibleNum;
    }
}