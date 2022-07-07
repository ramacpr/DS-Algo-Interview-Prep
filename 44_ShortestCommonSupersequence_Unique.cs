using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/shortest-common-supersequence0322/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=2&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page2category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    static class ShortestCommonSupersequence_Unique
    {
        public static void PrintResult()
        {
            PrintSCSS("priyanka", "jayaraj");
        }

        static void PrintSCSS(string str1, string str2)
        {
            HashSet<char> uniqueChars = new HashSet<char>();
            string result = string.Empty; 

            foreach(var c in str1)
            {
                if (uniqueChars.Contains(c))
                    continue;
                uniqueChars.Add(c);
                result += c.ToString(); 
            }

            foreach (var c in str2)
            {
                if (uniqueChars.Contains(c))
                    continue;
                uniqueChars.Add(c);
                result += c.ToString();
            }

            Console.WriteLine($"The shortest common super sequence for '{str1}' and '{str2}' is '{result}'");

        }
    }
}
