using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/print-anagrams-together/1/?difficulty[]=1&page=1&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&query=difficulty[]1page1category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    static class Anagrams
    {
        public static void PrintAnagramGroups()
        {
            PrintAnagrams(new string[]
            {
                "act","god","cat","dog","tac"
            });
        }

        static void PrintAnagrams(string[] words)
        {
            Dictionary<int, List<string>> groups = new Dictionary<int, List<string>>(); 

            for(int i = 0; i < words.Length; i++)
            {
                var hash = GetCode(words[i]);
                List<string> group = null;

                if (!groups.TryGetValue(hash, out group))
                    group = new List<string>();
                group.Add(words[i]);
                groups[hash] = group;
            }

            foreach(var kv in groups)
            {
                foreach (var anagram in kv.Value)
                    Console.Write($"{anagram} ");
                Console.Write("\n");
            }

        }

        static int GetCode(string word)
        {
            int code = 0;

            foreach (char c in word)
                code += (int)c;

            return code; 
        }
    }
}
