/*
A university has one turnstile. It can be used either as an exit or an entrance. unfortunately, sometimes many people want to pass through the turnstile and their directions can be deifferent. The ith person comes to the turnstile at time [i] and wants to either exit the university if direction[i] = i or enter the university if direction[i] = 0. People form 2 queues, one to exit and one to enter. They are ordered by the time when they came to the turnstile and, if the times are equal, by their indices. 

If some person wants to enter the university and another person wants to leave the university at the same moment there are three cases:
- If in the previous second the turnstile was not used, then the person who wants to leave goes first
-If in the previous second the turnstile was used as an exit , then the person who wants to leave goes first
-If in the previous second the turnstile was used as an entrance , then the person who wants to enter goes first

Passing through the turnstile takes 1 second. For each person , find the time they will pass through the turnstile

Complete the function with the parameters

int time[n] - and array of the n integers where the value at index i is the time in seconds when the ith person will come to the turnstile

int direction[n] - an array of n integers where the value at index i is the direction of the ith person

returns an array of n integers where the value at index i is the when the ith person will pass.





*/

public static int[] GetTimes(int[] times, int[] directions)
    {
        int entrySize = 0;//keep track of entry size array
        int exitSize = 0;//keep track of exit size array

        int entryUsed =0; //keep track of used entry arrays
        int exitUsed = 0; // keep track of used exit arrays

        bool previousEntry = false; //keeps track of if previous second was an entry or not
        bool previousNotUsed = true; //keeps track of if previous second was used at all


        int[] returnTimes = new int [times.GetLength(0)];//init a new return array

        int[,] entry = new int[times.GetLength(0),times.GetLength(0)];//init a entry array
        int[,] exit = new int[times.GetLength(0),times.GetLength(0)]; //init a exit array
        
        //loop through the times list and seperate times into exit and entry array for numbering purposes.
        for(int i = 0; i < times.GetLength(0); i++)
        {
            //labels the 2d array based on if exit or not in directions array
            if(directions[i] == 1)
            {
                Console.WriteLine("Leaving i="+i+" time="+times[i]);
                exit[exitSize,0] = i;
                exit[exitSize,1] = times[i];
                exitSize += 1;
            }
            else
            {
                Console.WriteLine("Enter i="+i+" time="+times[i]);
                entry[entrySize,0] = i;
                entry[entrySize,1]= times[i];
                entrySize += 1;
            }
        }

        //for loop for each ith person
        for (int i = 0; i < times.GetLength(0); i++)
        {
            //if statement if the entry matches the ith person
            if(i == entry[entryUsed,0])
            {
                //this is for looping purposes so that we can add values based on multiple values in exit array. Time Not is to cancel the loop if finished with finding value. Counter is for adding 1 to index of comparing exit array
                bool timeNot = true;
                int Counter = 0;
                while(timeNot)
                {
                    
                    //Checks if the time values match for the two arrays
                    if(exit[exitUsed+Counter,1] == entry[entryUsed,1])
                    {
                        //if  not used and is a exit i add 1 to the time of entry value then add to the counter to compare the next exit value
                        if(previousNotUsed || !previousEntry)
                        {
                            entry[entryUsed,1] +=1;
                            Counter+=1;
                        }
                        //Otherwise just keep the value and update the variables so the loops know the previous second
                        else
                        {
                            returnTimes[i] = entry[entryUsed,1];
                            timeNot = false;
                            previousNotUsed = false;
                            previousEntry = true;
                            entryUsed +=1;
                        }
                    }
                    //keep current value and update variables for next loop
                    else
                    {
                        returnTimes[i] = entry[entryUsed,1];
                        timeNot = false;
                        previousNotUsed = false;
                        previousEntry = true;
                        entryUsed +=1;
                    }
                }
            }
            //checks if ith matches the exit array and
            else if(i == exit[exitUsed,0])
            {
                //variables to keep track to compare against the entry array
                bool timeNot = true;
                int Counter = 0;
                while(timeNot)
                {
                    // does the same thing as the other if statement but compare the exit values and change it depending on the entry array value
                    if(exit[entryUsed+Counter,1] == exit[exitUsed,1])
                    {
                        if(previousNotUsed || previousEntry)
                        {
                            exit[exitUsed,1] +=1;
                            Counter+=1;
                        }
                        else
                        {
                            returnTimes[i] = exit[exitUsed,1];
                            timeNot = false;
                            previousNotUsed = false;
                            previousEntry = false;
                            exitUsed +=1;
                        }
                    }
                    else
                    {
                        returnTimes[i] = exit[exitUsed,1];
                        timeNot = false;
                        previousNotUsed = false;
                        previousEntry = false;
                        exitUsed +=1;
                    }
                }
            }
            //update variables since nothing was choosen
            else
            {
                previousNotUsed = true;
                previousEntry = false;
            }   
        }
        for (int i = 0; i < returnTimes.GetLength(0); i++)
        {
            Console.WriteLine("return ="+returnTimes[i]);
        }
        return times;
    }