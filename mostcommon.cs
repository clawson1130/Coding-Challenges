/*
Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.

Words in the list of banned words are given in lowercase, and free of punctuation.  Words in the paragraph are not case sensitive.  The answer is in lowercase.

*/


public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        //convert string to lower
        paragraph = paragraph.ToLower();
        //replace all the extra characters that aren't words
        paragraph = paragraph.Trim( new Char[] { ',', ',', '.' } );
        paragraph = paragraph.Replace("," , "");
        Console.WriteLine(paragraph);
        //convert string to array by empty space
        string[] para = paragraph.Split(" ");

        //create a dictionary for counting words
        Dictionary<string, int> dict = new Dictionary<string, int>();
        //loop each word in paragraph
        foreach(string word in para)
        {
            //if not in banned array the loop continues
            if(!banned.Contains(word))
            {
                //if dictionary already contains word get the value from the key and add to it otherwise createa new dictionary key pair
                if(dict.ContainsKey(word))
                {
                    
                    int val = dict[word];
                    dict[word] = val + 1;
                    Console.WriteLine("ContainsKey val="+val+"  newVal="+dict[word]);
                }
                else
                {
                    dict.Add(word,1);
                }
            }
        }
        //get and return the key with max value.
        var keyOfMaxValue = dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;     
        return keyOfMaxValue;
    }
}