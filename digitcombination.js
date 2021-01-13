/**
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
 */

 //function that returns the results.
var letterCombinations = function(digits) {
    
    //returns the alphabet corresponding with the digits
    var alphabet = createList(digits);
    
    //returns the possible combination with the digits
    var result = combine(alphabet,[]);
    return result;

};

//recursive function that returns the combination possibilities from bottom up
var combine = function(list, returnlist)
{
    //condition to return function once list is completely empty
    if(list.length == 0)
    {
        return returnlist;
    }
    else
    {
        //create an arr with the last array in the 2d array while removing it from the list 
        var arr = list.pop();

        //if it is the first time using returnList is empty , so call the function again
        if(returnlist.length == 0)
        {
            return combine(list,arr);
        }
        else
        {
            //init a array that will be used as the returnList when combine is called again
            var ret = []

            // loop through the letters in the popped out arr created
            for(letter of arr)
            {

                //for the strings in returnList , we r going to add the letter on top of that string and then add that to the ret array
                for(letter2 of returnlist)
                {
                    ret.push(letter.concat(letter2));
                }
            }
            //recall the combine function again and past the list and newly created ret array as returnlist
            return combine(list, ret)
        }
    }
    
}
//creates a twodimensional array with the arrays corresponding to the digits
//a for loop is used for this
var createList = function(digits)
{
    var retarr = [];
    for(i = 0 ; i < digits.length; i++)
    {
        retarr.push(returnLetters(parseInt(digits[i])))
        //console.log(retarr[i]);
    }
    return(retarr);
}
//function that use the switch conditions to return an array with the right letters based on the digits
var returnLetters = function(digit) {
    
    var arr;
    
    switch(digit)
    {
        case 2:
            var arr= ["a","b","c"];
            break;
        case 3:
            arr =  ["d","e","f"];
            break;
        case 4:
            arr =  ["g","h","i"];
            break;
        case 5:
            arr =  ["j","k","l"];
            break;
        case 6:
            arr =  ["m","n","o"];
            break;
        case 7:
            arr =  ["p","q","r","s"];
            break;
         case 8:
            arr =  ["t","u","v"];
            break;
        case 9:
            arr =  ["w","x","y","z"];
            break;
        default:
            arr = [];
    }
    return (arr);
    
};