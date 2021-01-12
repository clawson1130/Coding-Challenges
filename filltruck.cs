
/*
You are assigned to put some amount of boxes onto one truck. You are given a 2D array boxTypes, where boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:

numberOfBoxesi is the number of boxes of type i.
numberOfUnitsPerBoxi is the number of units in each box of the type i.
You are also given an integer truckSize, which is the maximum number of boxes that can be put on the truck. You can choose any boxes to put on the truck as long as the number of boxes does not exceed truckSize.

Return the maximum total number of units that can be put on the truck.
*/


public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        
        Console.WriteLine("HelloWorld");
        //keep track of expected return
        int expected = 0;
        //sort array to which one has greatest units
        Array.Sort(boxTypes, (a, b) => {return b[1] - a[1];});
        //loop through the boxTypes until the truckSize is 0
        for(int i = 0; i < boxTypes.GetLength(0) && truckSize != 0; i++)
        {
            //IF BOXES FIT INTO TRUCK ADD THEM TO EXPECTED AND SUBTRACT FROM TRUCK SIZE
            if(boxTypes[i][0]<= truckSize)
            {
                expected += (boxTypes[i][0] * boxTypes[i][1]);
                truckSize -= boxTypes[i][0];
            }
            else
            {
                //ELSE IF SUBTRACT THE VALUE INTO WE GET A NUMBER THAT FITS INTO THE TRUCK 
                int valueNum = boxTypes[i][0];
                while(valueNum > truckSize)
                {
                    valueNum -= 1;
                    if(valueNum <= truckSize)
                    {
                        expected += (valueNum * boxTypes[i][1]);
                        truckSize -= valueNum;
                        break;
                    }
                }
            }
                
        }
        
        return expected;
    }
}