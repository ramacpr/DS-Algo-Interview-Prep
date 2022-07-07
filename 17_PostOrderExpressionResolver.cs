using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep.Tree
{
    /*
    Given an arithmetic expression in Reverse Polish Notation, 
    write a program to evaluate it. The expression is given as a list of 
    numbers and operands. For example: [5, 3, '+'] should return 5 + 3 = 8.
    
    For example, [15, 7, 1, 1, '+', '-', '/', 3, '*', 2, 1, 1, '+', '+', '-'] 
    should return 5, since it is equivalent to 
    ((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)) = 5.
    
    You can assume the given expression is always valid.
    */

    public enum OperatorType
    {
        Add, 
        Substract, 
        Multiply,
        Divide,
        NotAnOperator
    }

    #region ValueNodes
    public interface IValueNode
    {
        int GetNodeValue();
        void SetNodeValue(int value);
    }

    public class ValueNode : IValueNode
    {
        int? _value = null;

        public int GetNodeValue()
        {
            return (int)_value;
        }

        public void SetNodeValue(int value)
        {
            _value = value;
        }
    } 
    #endregion

    #region OperatorNodes
    public interface IOperatorNode 
    {
        int? DoOperation(int lValue, int rValue);
    }
    class AddOperator : IOperatorNode
    {
        public int? DoOperation(int lValue, int rValue)
        {
            return (lValue + rValue);
        }
    }
    class SubstractOperator : IOperatorNode
    {
        public int? DoOperation(int lValue, int rValue)
        {
            return (lValue - rValue);
        }
    }
    class MultiplyOperator : IOperatorNode
    {
        public int? DoOperation(int lValue, int rValue)
        {
            return (lValue * rValue);
        }
    }

    class DivideOperator : IOperatorNode
    {
        public int? DoOperation(int lValue, int rValue)
        {
            if (rValue == 0)
            {
                return null;
            }
            return (lValue / rValue);
        }
    } 
    #endregion

    public class ExpressionTreeNode
    {
        protected bool _isOperator = false;
        protected ExpressionTreeNode leftNode = null;
        protected ExpressionTreeNode rightNode = null;

        public bool IsOperator() => this._isOperator; 

        public void SetLeftNode(ExpressionTreeNode lNode) => this.leftNode = lNode;
        public ExpressionTreeNode GetLeftNode() => this.leftNode;

        public void SetRightNode(ExpressionTreeNode rNode) => this.rightNode = rNode;
        public ExpressionTreeNode GetRightNode() => this.rightNode;
    }

    public class ExpressionTreeValueNode : ExpressionTreeNode
    {
        IValueNode valueNode = null;
        
        public ExpressionTreeValueNode(int value)
        {
            base._isOperator = false;

            valueNode = new ValueNode();
            valueNode.SetNodeValue(value);
        }

        public int GetValue() => valueNode.GetNodeValue();
    }

    public class ExpressionTreeOperatorNode : ExpressionTreeNode
    {
        IOperatorNode opNode = null; 
        public ExpressionTreeOperatorNode(OperatorType operatorType)
        {
            base._isOperator = true;
            switch (operatorType)
            {
                case OperatorType.Add:
                    opNode = new AddOperator();
                    break;
                case OperatorType.Substract:
                    opNode = new SubstractOperator();
                    break;
                case OperatorType.Multiply:
                    opNode = new MultiplyOperator();
                    break;
                case OperatorType.Divide:
                    opNode = new DivideOperator();
                    break;
                default:
                    throw new InvalidOperationException(); 
            }
        }

        public int? DoOperation(int lValue, int rValue) => opNode.DoOperation(lValue, rValue);
    }


    public class PostOrderExpressionResolver
    {
        ExpressionTreeNode root = null; 

        public int? GetExpressionResult(string[] expression)
        {
            int? result = null;

            // O(n)
            if (!BuildExpressionTree(expression))
            {
                Console.WriteLine("ERROR: Invalid postOrder expression!!!");
                return null;
            }

            // O(n)
            // now process the expression.... 
            if((result = CalculateExpression(root)) == null)
            {
                Console.WriteLine("ERROR: Calculation error. Possible invalid expression");
                return null; 
            }

            return result; 
        }

        // inorder traversal here... recurssion!!!
        int? CalculateExpression(ExpressionTreeNode currNode)
        {
            if (currNode == null) return null;
            if (!currNode.IsOperator())
                return ((ExpressionTreeValueNode)currNode).GetValue();

            ExpressionTreeOperatorNode opNode = (ExpressionTreeOperatorNode)currNode;

            var lNode = opNode.GetLeftNode();
            if (lNode == null) return null; 
            var lValue = CalculateExpression(lNode);
            if (lValue == null) return null;

            var rNode = opNode.GetRightNode();
            if (rNode == null) return null; 
            var rValue = CalculateExpression(rNode);
            if (rValue == null) return null; 

            return opNode.DoOperation((int)lValue, (int)rValue);
        }

        bool BuildExpressionTree(string[] expression)
        {
            // root of tree is always operator, 
            // then right node (value/operator)
            // then at last the left node (value/operator)
            if (expression.Length <= 2) return false;

            Stack<ExpressionTreeNode> stack = new Stack<ExpressionTreeNode>();

            var rootOp = GetOperator(expression[expression.Length - 1]);
            if (rootOp == OperatorType.NotAnOperator) return false;
            root = new ExpressionTreeOperatorNode(rootOp);
            stack.Push(root);

            ExpressionTreeNode node = null; 
            int index = expression.Length - 2; 
            for(; index >= 0; index--)
            {               
                var op = GetOperator(expression[index]);
                if(op == OperatorType.NotAnOperator)
                {
                    int value = -1;
                    if (int.TryParse(expression[index].ToString(), out value) == false) return false; 

                    var newValueNode = new ExpressionTreeValueNode(value);
                    node = stack.Peek();
                    while (stack.Count > 0 &&
                        node.GetRightNode() != null && node.GetLeftNode() != null)
                    {
                        stack.Pop();
                        node = stack.Peek();
                    }

                    if (stack.Count == 0) return false;

                    node = stack.Peek();

                    if (node.GetRightNode() == null)
                        node.SetRightNode(newValueNode);
                    else
                        node.SetLeftNode(newValueNode);
                }
                else
                {
                    var newOpNode = new ExpressionTreeOperatorNode(op);
                    node = stack.Peek();
                    while (stack.Count > 0 &&
                        node.GetRightNode() != null && node.GetLeftNode() != null)
                    {
                        stack.Pop();
                        node = stack.Peek();
                    }

                    if (stack.Count == 0) return false;

                    if (node.GetRightNode() == null)
                        node.SetRightNode(newOpNode);
                    else
                        node.SetLeftNode(newOpNode);

                    stack.Push(newOpNode);
                }
            }

            // even after all the nodes in the expression are built, 
            // if there are any nodes in the tree with free left/right child nodes
            // it means that the expression is invalid. 
            // a valid expression tree is always a complete tree. 
            node = stack.Peek();
            while (stack.Count > 0)
            {
                node = stack.Peek();
                if (node.GetLeftNode() != null && node.GetRightNode() != null)
                    stack.Pop();
                else // even if one of the childs are empty, expression is invalid.  
                    return false;                
            }

            return true; 
        }

        OperatorType GetOperator(string o)
        {
            if (o == "+")
                return OperatorType.Add;
            if (o == "-")
                return OperatorType.Substract;
            if (o == "*")
                return OperatorType.Multiply;
            if (o == "/" || o == "\\")
                return OperatorType.Divide;
            return OperatorType.NotAnOperator;
        }
    }
}
