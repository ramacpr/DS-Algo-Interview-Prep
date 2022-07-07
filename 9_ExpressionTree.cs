using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/construct-an-expression-tree/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=1&query=category[]Treedifficulty[]1page1category[]Tree

namespace GPrep
{
    class ExpNode
    {
        public char data;
        public ExpNode left;
        public ExpNode right;

        public ExpNode(char val) => data = val;
    }

    static class ExpressionTree
    {
        public static void Construct()
        {
            string postExp = "wlrb+-*";
            var expTree = ConstructExpressionTree(postExp.ToCharArray());
            PrintInOrder(expTree);

        }

        static void PrintInOrder(ExpNode tree)
        {
            if (tree == null)
                return;

            PrintInOrder(tree.left);
            Console.Write(tree.data);
            PrintInOrder(tree.right);
        }

        static ExpNode ConstructExpressionTree(char[] postOrderExp)
        {
            if (postOrderExp.Length <= 2)
            {
                Console.WriteLine("NotAnOperator Expression!");
                return null;
            }

            int index = postOrderExp.Length - 1;
            Stack<ExpNode> operatorStk = new Stack<ExpNode>();
            ExpNode tree = null, currOperatorNode = null;

            // the last node is the root of the tree. 
            tree = new ExpNode(postOrderExp[index]);
            currOperatorNode = tree;
            operatorStk.Push(currOperatorNode);

            index -= 1;
            for (; index >= 0; index--)
            {
                while ((currOperatorNode == null) || (currOperatorNode.left != null && currOperatorNode.right != null))
                {
                    currOperatorNode = operatorStk.Peek();
                    if (currOperatorNode.left != null && currOperatorNode.right != null)
                        currOperatorNode = operatorStk.Pop();
                }

                if (IsOperator(postOrderExp[index]))
                {                                 
                    if (currOperatorNode.right == null)
                    {
                        currOperatorNode.right = new ExpNode(postOrderExp[index]);
                        currOperatorNode = currOperatorNode.right;
                    }
                    else if(currOperatorNode.left == null)
                    {
                        currOperatorNode.left = new ExpNode(postOrderExp[index]);
                        currOperatorNode = currOperatorNode.left;
                    }
                    else
                    {
                        Console.WriteLine("NotAnOperator Expression!");
                        return null; 
                    }
                    
                    operatorStk.Push(currOperatorNode);
                }
                else
                {
                    if(currOperatorNode == null)
                    {
                        Console.WriteLine("NotAnOperator expression");
                        return null; 
                    }

                    if(operatorStk.Count == 0)
                    {
                        Console.WriteLine("NotAnOperator input expression!");
                        return null;
                    }
                    // first push it to right, then left
                    currOperatorNode = operatorStk.Pop();
                    if(currOperatorNode.right == null)
                        currOperatorNode.right = new ExpNode(postOrderExp[index]);
                    else
                        currOperatorNode.left = new ExpNode(postOrderExp[index]);

                    if (currOperatorNode.left == null || currOperatorNode.right == null)
                        operatorStk.Push(currOperatorNode);
                    else
                        currOperatorNode = null;
                }
            }
            return tree;
        }

        static bool IsOperator(char op)
        {
            HashSet<char> operators = new HashSet<char>(new char[] { '+', '/', '*', '-' });

            return operators.Contains(op) ? true : false;
        }
    }
}
