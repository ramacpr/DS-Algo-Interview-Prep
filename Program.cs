using GPrep.Matrix;
using GPrep.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            #region max XOR subarray
            //MaxXORSubarr.MaximumXOR(new int[] {4,6}); 
            #endregion

            #region height of binary tree
            //HeightOfBinaryTree.PrintHeightOfTree(); 
            #endregion


            #region check for BST
            //CheckBST.CheckForBST();  
            #endregion

            #region max sum adjacent nodes - BST
            //MaxSumAdjNodesBT.PrintMaxSumAdjNodes(); 
            #endregion

            #region Nuts and bolts matching
            //NutsAndBolts.MatchNutsAndBolts(); 
            #endregion

            #region shortest path between cities
            //ShortestPathBetweenCities.PrintShortestDist();  
            #endregion

            #region lrgest independent set
            //LargestIndependentSet.PrintLIS(); 
            #endregion

            #region binary tree clone
            //BTClone.DoClone();  
            #endregion

            #region Expression tree construction
            // ExpressionTree.Construct(); 
            #endregion

            #region subtree count with sum
            // SubTreeCntWithSum.FindSubtreeCount(); 
            #endregion

            #region BST nodes in range
            // BSTNodesInRange.PrintCountOfNodesInRng(); 
            #endregion

            #region closest node in BST
            // ClosestNodeinBST.PrintClosestNode();  
            #endregion

            #region extreme alternate nodes
            // ExtremeAlternateNodes.PrintExtremeAlternateNodes(); 
            #endregion

            #region connect same level nodes
            // ConnectSameLevelNodes.ConnectLevelNodes(); 
            #endregion

            #region BT from parent array
            // BTFromParentArr.ConstructBTFromParentArr(); 
            #endregion

            #region Least common ancestor
            // LeastCommonAncestor.PrintLCANode(); 
            #endregion

            #region connected nodes in order
            // ConnectNodesInOrder.ConnectInOrder(); 
            #endregion

            #region bottom view of binary tree
            // BottomViewBT.PrintBottomView(); 
            #endregion

            #region Serialize-Deserialize BT
            // SerializeDeserialize.SerializeDeserializeBT();  
            #endregion

            #region JobScheduler
            // JobScheduler.PrintJobsScheduled();  
            #endregion

            #region Trie
            /*Trie tr = new Trie();
                tr.InsertWord("apple").InsertWord("home").InsertWord("office").InsertWord("off").InsertWord("offer").InsertWord("amber")
                    .InsertWord("acne").InsertWord("accute").InsertWord("ample").InsertWord("arm").InsertWord("hope");
                Console.WriteLine($"Is [apple] present =>{tr.IsWordPresent("apple")}");
                Console.WriteLine($"Is [apples] present =>{tr.IsWordPresent("apples")}");
                Console.WriteLine($"Is [app] present =>{tr.IsWordPresent("app")}");
                Console.WriteLine($"Is [offer] present =>{tr.IsWordPresent("offer")}");
                Console.WriteLine($"Is [amp] present =>{tr.IsWordPresent("amp")}");
                Console.WriteLine($"Is [hope] present =>{tr.IsWordPresent("hope")}");
                Console.WriteLine($"Is [hopes] present =>{tr.IsWordPresent("hopes")}");
                Console.WriteLine($"Is [offer] present =>{tr.IsWordPresent("offer")}");
                tr.DeleteWord("offer");
                Console.WriteLine($"Is [offer] present =>{tr.IsWordPresent("offer")}");*/
            #endregion

            #region anagrams
            // Anagrams.PrintAnagramGroups();  
            #endregion

            #region letters collection
            // LettersCollection.PrintHopAwaySums(); 
            #endregion

            #region segment tree
            // REDO!!!
            /*SegmentTree st = new SegmentTree();
            st.ConstructST(new int[] { 4, 7, 12, 2, 8, 3 });
            Console.WriteLine($"Sum Query from 1 to 4 is {st.SumQueryNew(1, 4, 0, 5)}");*/
            #endregion

            #region sorted matrix search
            // SortedMatrixSearch.PrintSearchResults(); 
            #endregion

            #region nearly sorted array
            // NearlySortedArray.SortNearySortedArr(); 
            #endregion

            #region merge K sorted
            // MergeKSorted.PrintResult(); 
            #endregion

            #region max contigious sum
            // MaxContigiousSumSubArr.Printresult();  
            #endregion

            #region re-arrange alternate array
            // RearrangeAlternateArray.PrintResult();
            #endregion

            #region equal 0 and 1 subarr
            // Equal0s1sSubArr.PrintResult(); 
            #endregion

            #region longest even length substring
            // LongestEvenLengthSubStr.PrintResult(); 
            #endregion

            #region arr triplet sum
            // ArrTripletSum.PrintResult(); 
            #endregion

            #region spiral matrix traversal
            // SpiralMatrixTraversal.PrintResult(); 
            #endregion

            #region shortest common super-sequence
            // ShortestCommonSupersequence_Unique.PrintResult(); 
            #endregion

            #region kth smallest matrix
            // kthSmallestMatrix.PrintResult();  
            #endregion

            #region trapped water
            // TrappedWater.PrintResult();
            #endregion

            #region smallest window string
            // SmallestWndString.PrintResult();  
            #endregion


            #region longest common subsequence
            // LongestCommonSubsequence.PrintResult();
            #endregion

            #region X total shapes
            // XTotalShapes.PrintResult();  
            #endregion

            #region Minimum platforms
            // MinimumPlatforms.PrintResult(); 
            #endregion

            #region strogly connected components
            // !!! StronglyConnectedComponents.PrintResult() 
            #endregion

            #region page fault in LRU
            // PageFaultsInLRU.PrintResult();  
            #endregion

            #region min sum sub-array
            // MinimumSubarray.PrintResult();  
            #endregion

            #region word boggle
            // WordBoggle.PrintResult();  
            #endregion

            #region Largest rectangle under histogram
            //LargestRectangleUnderHistogram p = new LargestRectangleUnderHistogram();
            //Console.WriteLine(p.getMaxArea(new int[] { 6, 2, 5, 4, 5, 1, 6 })); 
            #endregion

            #region largest rectangle in matrix
            //LargestRectangleInMatrix p = new LargestRectangleInMatrix();
            //Console.WriteLine(p.GetLargestRectangleArea()); 
            #endregion

            #region postorder math expression resolver
            //PostOrderExpressionResolver p = new PostOrderExpressionResolver();
            //var res = p.GetExpressionResult(new string[15]{ "15", "7", "1", "1", "+", "-", "/", "3", "*", "2", "1", "1", "+", "+", "-"});
            //if (res != null)
            //    Console.Write(" = " + res); 
            #endregion

            #region longest absolute path to file
            //string path = "dir\n\tsubdir1\n\t\tfile1\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2";//"dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
            //LongestAbsPathToFile p = new LongestAbsPathToFile(path);
            //Console.WriteLine(p.GetLongestAbsFilePath());  
            #endregion

            #region Longest Palindromic Subsequence
            //Console.WriteLine("=> " + LongestPalindromicSubstring.GetLongestPalindromicSubsequence("bananas"));
            #endregion

            #region Nearly sorted list
            //var arr = new int[] { 20, 46, 89, 10, 93, 35, 109, 78, 209, 102, 97 };
            //foreach(var item in arr)
            //    Console.Write(item + ", ");
            //Console.WriteLine("");
            //var sortedarr = NearlySortedList.Sort(arr, 3);
            //foreach (var sitem in sortedarr)
            //    Console.Write(sitem + ", ");
            #endregion

            #region Smallest word ladder/path length
            WordLaddar p = new WordLaddar();
            Console.WriteLine(p.GetWordLaddarLength("toon", "plea"));

            #endregion

            Console.ReadLine();
        }
    }
}
