/*

Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

Return the quotient after dividing dividend by divisor.

The integer division should truncate toward zero, which means losing its fractional part. For example, truncate(8.345) = 8 and truncate(-2.7335) = -2.


*/




class Solution {

    //returns the quotient from the imported dividend, and divisor
    func divide(_ dividend: Int, _ divisor: Int) -> Int {
        

        // first I check if the result of dividing would be negative or positive and pass it as a bool value
        var negative = ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0)) ?  true : false

        //run the divrec function to get exact times
        let result = divrec(dividend : dividend, divisor : divisor , times : 0, sum : 0, isNeg : negative)

        //return the result
        return result
    }
    //recursive function that returns the quotient
    func divrec(dividend:Int, divisor:Int, times: Int, sum : Int, isNeg: Bool) -> Int
    {

        //get the absolute value of both
        let absdividend = abs(dividend)
        let absdivisor = abs(divisor)

        //is the case that returns the recursive function and that is only if the sum is greater than or equal to the dividend
        if(sum >= absdividend)
        {
            
            // if the sum is greater than the dividend i subtract the overall times number, otherwise I pass the time number to result
            var result = (sum > absdividend) ? (times - 1) : times

            //if it is negative from the parameter I change the result to a negative number 
            if(isNeg)
            {
                result.negate()
            }
            //return the final quotient number
            return result
        }
        else
        {
            //combine the absolute value of divisor and the sum of everything combined so far
            let combine = absdivisor + sum

            //increment the times by 1 because that's how much we are times it by
            var time = times + 1
            
            //call the function inside itself.
            return divrec(dividend : absdividend, divisor : absdivisor , times : time, sum : combine, isNeg: isNeg)
        }
    }
}
