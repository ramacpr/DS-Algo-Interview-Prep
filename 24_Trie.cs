using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class TNode
    {
        public char? Alphabet;
        public Dictionary<char, TNode> CharacterSet = new Dictionary<char, TNode>(); 

        public TNode(char character) => Alphabet = (char?) character;
        public TNode() => Alphabet = null;
    }

    public class Trie
    {
        TNode root = new TNode();
        object lockPad = new object();

        public Trie InsertWord(string word)
        {
            lock (lockPad)
            {
                RealInsertNode(root, word);
                return this;
            }
        }

        void RealInsertNode(TNode root, string word, int index = 0)
        {
            if (index >= word.Length)
                return; 

            var node = GetTNodeForChar(root, word[index]);
            if (node == null) // insert new node for this aphabet
            {
                node = new TNode(word[index]);
                root.CharacterSet[word[index]] = node;               
            }
            RealInsertNode(node, word, index + 1);
        }

        public bool IsWordPresent(string word)
        {
            lock (lockPad)
            {
                return RealIsWordPresent(root, word);
            }
        }

        bool RealIsWordPresent(TNode root, string word, int index = 0)
        {
            if (index >= word.Length)
                return true;

            var node = GetTNodeForChar(root, word[index]);
            if (node == null) // insert new node for this aphabet
                return false;
            return RealIsWordPresent(node, word, index + 1);
        }

        public void DeleteWord(string word)
        {
            lock (lockPad)
            {
                RealDeleteWord(word);
            }
        }

        void RealDeleteWord(string word)
        {
            Stack<TNode> st = new Stack<TNode>();
            TNode curr = root; 
            for(int index = 0; index < word.Length; index++)
            {
                var node = GetTNodeForChar(curr, word[index]);
                if (node == null)
                    return; // word not present
                st.Push(node);
                curr = node;
            }

            curr = st.Pop(); 
            while(curr.CharacterSet.Count == 0)
            {
                st.Peek().CharacterSet.Remove((char)curr.Alphabet);
                curr = st.Pop(); 
            }            

        }        

        TNode GetTNodeForChar(TNode node, char alphabet)
        {
            TNode result = null;

            if (node == null)
                return null;

            return (!node.CharacterSet.TryGetValue(alphabet, out result)) ? null : result;
        }
    }
}
