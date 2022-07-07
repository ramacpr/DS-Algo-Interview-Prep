using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    /*
    Suppose we represent our file system by a string in the following manner:
    The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
        dir
            subdir1
            subdir2
                file.ext
    The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 
    containing a file file.ext. 
    The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"
    represents:
        dir
            subdir1
                file1.ext
                subsubdir1
            subdir2
                subsubdir2
                    file2.ext

    The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains 
    a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a 
    second-level sub-directory subsubdir2 containing a file file2.ext.
    
    We are interested in finding the longest (number of characters) absolute path 
    to a file within our file system. For example, in the second example above, the 
    longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 
    (not including the double quotes).
    
    Given a string representing the file system in the above format, 
    return the length of the longest absolute path to a file in the abstracted file system. 
    If there is no file in the system, return 0.

    Note:
    The name of a file contains at least a period and an extension.
    The name of a directory or sub-directory will not contain a period.
    */

    public class LPTreeNode
    {
        public string Description;
        public int Value;
        List<LPTreeNode> childred = new List<LPTreeNode>(); 

        public LPTreeNode(string description, int value)
        {
            this.Description = description;
            this.Value = value;
        }

        public void AddChild(string desc, int value)
        {
            childred.Add(new LPTreeNode(desc, value));
        }

        public void AddChild(LPTreeNode child)
        {
            childred.Add(child);
        }

        public int GetChildCount() => childred.Count;

        public IEnumerable<LPTreeNode> GetNextChild()
        {
            foreach (var child in childred)
                yield return child;
        }
    }

    public class LongestAbsPathToFile
    {
        string _inputString;
        LPTreeNode root = null; 

        public LongestAbsPathToFile(string input)
        {
            this._inputString = input;
        }

        public int GetLongestAbsFilePath()
        {
            int pathLen = 0;
            Dictionary<int, LPTreeNode> levelwisePrevNodeMap = new Dictionary<int, LPTreeNode>();
            LPTreeNode prevLevelNode = null;
            int currLevel = 0;

            #region step 1:
            // step 1: 
            // split the string with \n as delimiter, 
            // this returns desc of directory/file name
            string[] descriptions = _inputString.Split('\n');
            if (descriptions.Length <= 0) // error scenario
                return -1;
            #endregion

            #region step 2:
            // step 2: 
            // the first description is always the root node (assuming only single root) 
            // the number of \t's in the description determined the level of the description. 
            // ex: 'dir\n\tfolder1\n\t\tfile1.txt' here, 
            //      dir is root -> \t count = 0 -> level = 0
            //      folder1 -> \t count = 1 -> level = 1
            //      file1.txt -> \t count = 2 => level = 2
            // so its tree/graph would look like...
            // (dir) -> (folder1) -> (file1.txt)
            //      
            // here each node can have multiple children. 
            // Now, build this tree here. 
            root = new LPTreeNode(descriptions[0], descriptions[0].Length);
            levelwisePrevNodeMap.Add(currLevel, root);

            for (int index = 1; index < descriptions.Length; index++)
            {
                var newDescription = descriptions[index];
                string[] description = newDescription.Split('\t');
                int newLevel = description.Length - 1;
                var newNode = new LPTreeNode(description[description.Length - 1], description[description.Length - 1].Length);

                if (!levelwisePrevNodeMap.TryGetValue(newLevel - 1, out prevLevelNode)) // error 
                    return -1;

                prevLevelNode.AddChild(newNode);
                levelwisePrevNodeMap[newLevel] = newNode;
            }
            #endregion

            #region step 3: O(V*E)
            // step 3: 
            // on the created graph, perform DFS and keep track of the max value in each path. 
            // the path with max sum is the final result.
            pathLen = DFS(root, root.Value); 
            #endregion

            return pathLen;
        }

        int DFS(LPTreeNode node, int levelSum)
        {
            int maxSum = levelSum;

            // if this is the leaf node, it has to be a file, else 
            // dont consider this path!
            if (node.GetChildCount() == 0 && !node.Description.Contains('.'))
                return -1; 

            foreach(var child in node.GetNextChild())
            {
                var newsum = DFS(child, levelSum + child.Value);
                if (newsum > maxSum)
                    maxSum = newsum;
            }

            if (maxSum == levelSum && node.GetChildCount() > 0)
                return 0; 

            return maxSum;

        }
    }
}
