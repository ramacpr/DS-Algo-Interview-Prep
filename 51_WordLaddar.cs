using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    /* Word Ladder (Length of shortest chain to reach a target word)
    Given a dictionary, and two words ‘start’ and ‘target’ 
    (both of same length). Find length of the smallest chain from 
    ‘start’ to ‘target’ if it exists, such that adjacent words in the 
    chain only differ by one character and each word in the chain is a valid word 
    i.e., it exists in the dictionary. It may be assumed that the ‘target’ word 
    exists in dictionary and length of all dictionary words is same. 
    
    Example: 
    Input: 
        Dictionary = {POON, PLEE, SAME, POIE, PLEA, PLIE, POIN}, 
    POON -> POOA
        start = TOON, 
        target = PLEA
    Output: 7
    Explanation: TOON – POON – POIN – POIE – PLIE – PLEE – PLEA
    
    Input: 
        Dictionary = {ABCD, EBAD, EBCD, XYZA}, 
        start = ABCV, 
        target = EBAD
    Output: 4
    Explanation: ABCV – ABCD – EBCD – EBAD
    */
    public class WordLaddar
    {
        List<string> vocab = new List<string>();
        HashSet<string> processedWords = new HashSet<string>();
        int SmallestWordPath = int.MaxValue;
        public WordLaddar()
        {
            vocab.Add("poon"); 
            vocab.Add("plee");
            vocab.Add("same");
            vocab.Add("poie");
            vocab.Add("plea");
            vocab.Add("plie");
            vocab.Add("poin");
        }
        public int GetWordLaddarLength(string startWord, string endWord)
        {
            if (!IsValidWord(endWord)) return 0; 

            processedWords.Add(startWord);
            Real_GetWordLaddarLength(startWord, endWord, 1);

            return SmallestWordPath;
        }

        void Real_GetWordLaddarLength(string startWord, string endWord, int level)
        {
            int wordLaddarLength = level;

            if (startWord == endWord)
            {
                if (wordLaddarLength < SmallestWordPath)
                    SmallestWordPath = wordLaddarLength; 
            }

            foreach (var nw in GetNextWords(startWord, ref processedWords))
                Real_GetWordLaddarLength(nw, endWord, level + 1); 
        }

        bool IsValidWord(string word) => vocab.Contains(word);

        List<string> GetNextWords(string word, ref HashSet<string> processedWords)
        {
            List<string> nextWords = new List<string>(); 
            char[] aplhabets = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] orgWord = word.ToArray(); 
            for(int i1 = 0; i1 < 26; i1++)
            {
                if (word[0] == aplhabets[i1]) continue;
                orgWord[0] = aplhabets[i1];
                for(int i2 = 0; i2 < 26; i2++)
                {
                    if (word[0] == aplhabets[i2]) continue;
                    orgWord[1] = aplhabets[i2];
                    for (int i3 = 0; i3 < 26; i3++)
                    {
                        if (word[0] == aplhabets[i3]) continue;
                        orgWord[2] = aplhabets[i3];
                        for (int i4 = 0; i4 < 26; i4++)
                        {
                            if (word[0] == aplhabets[i4]) continue;
                            orgWord[3] = aplhabets[i4];

                            var newWord = new string(orgWord);

                            // return this word only if its valid and has not been processed before.
                            if (!processedWords.Contains(newWord) && IsValidWord(newWord))
                            {
                                processedWords.Add(newWord);
                                nextWords.Add(newWord);
                            }
                            processedWords.Add(newWord);
                            continue;
                        }
                    }
                }
            }

            return nextWords;
        }
    }
}
