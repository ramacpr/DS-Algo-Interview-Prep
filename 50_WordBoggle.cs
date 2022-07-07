using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/word-boggle4143/1/?category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&difficulty[]=1&page=4&query=category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Treedifficulty[]1page4category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Tree

namespace GPrep
{
    static class WordBoggle
    {
        public static void PrintResult()
        {

        }

        static void MatchWords(char[,] board, List<string> words)
        {
            int rowCount = board.GetLength(0);
            int colCount = board.GetLength(1); 
            Dictionary<char, List<Tuple<int, int>>> boardPosition = new Dictionary<char, List<Tuple<int, int>>>();
            List<string> matchedWords = new List<string>();
            

            // update character positions on board
            for(int row = 0; row < rowCount; row++)
            {
                for(int col = 0; col < colCount; col++)
                {
                    List<Tuple<int, int>> cellLst = null; 
                    if(!boardPosition.TryGetValue(board[row, col], out cellLst))
                    {
                        cellLst = new List<Tuple<int, int>>();
                        cellLst.Add(new Tuple<int, int>(row, col));
                        boardPosition[board[row, col]] = cellLst;
                    }
                    else // found
                    {
                        if(boardPosition[board[row, col]] != null)
                            boardPosition[board[row, col]].Add(new Tuple<int, int>(row, col)); 
                    }
                }
            }
            
            foreach(var word in words)
            {
                bool allPresent = true;

                // board should have atleast one occurance of the characters in word
                Dictionary<char, int> charCount = new Dictionary<char, int>();
                for (int wi = 0; wi < word.Length; wi++)
                {
                    int count = 1;
                    if (!charCount.TryGetValue(word[wi], out count))
                        charCount[word[wi]] = 1;
                    else
                        charCount[word[wi]] += 1; 
                }

                for (int wi = 0; wi < word.Length; wi++)
                {
                    List<Tuple<int, int>> cellLst = null;
                    if ((!boardPosition.TryGetValue(word[wi], out cellLst)) || 
                        (charCount[word[wi]] < cellLst.Count))
                    {
                        allPresent = false;
                        break; 
                    }
                }

                if (allPresent == false)
                    continue;

                // all characters in required count are present on board, 
                // we need to find if they are next to each other now
                if (SearchWord(word, board, boardPosition))                
                    matchedWords.Add(word);

            }
        
        }

        static bool SearchWord(string word, char[,] board, Dictionary<char, List<Tuple<int, int>>> boardPosition)
        {
            int[,] isVisited = new int[board.GetLength(0), board.GetLength(1)];
            Stack<Tuple<int, int>> st = new Stack<Tuple<int, int>>(); 

            // Perform DFS to find the word in every possible board position 
            var positions = boardPosition[word[0]];
            int wi = 0; 
            foreach(var position in positions)
            {
                st.Push(position); 
                while(st.Count > 0 && wi < word.Length)
                {
                    var cell = st.Pop();
                    isVisited[cell.Item1, cell.Item2] = 1;
                    if (board[cell.Item1, cell.Item2] != word[wi])
                        continue; 
                    // else, check for next word in the neighbouring cells
                    // push neighbouring unvisited cells to stack. 
                    // ... 
                }

                if (wi >= word.Length) // word found on board!
                    return true; 
            }
            return false; 
        }


    }
}
