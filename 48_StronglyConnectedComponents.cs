using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class Vertex
    {
        public int data;
        public List<Vertex> next;

        public Vertex(int val) => data = val; 
        public void AddNext(Vertex v)
        {
            if (next == null)
                next = new List<Vertex>();
            next.Add(v); 
        }
    }
    static class StronglyConnectedComponents
    {
        public static void PrintResult()
        {
            Vertex startNode = new Vertex(0);
            var n1 = new Vertex(1);
            var n2 = new Vertex(2);
            var n3 = new Vertex(3);
            var n4 = new Vertex(4);
            startNode.AddNext(n2);
            startNode.AddNext(n3);
            n1.AddNext(startNode);
            n2.AddNext(n1);
            n3.AddNext(n4);

            int count = GetStronglyConnectedGraphCount(startNode);
        }

        private static int GetStronglyConnectedGraphCount(Vertex startNode)
        {
            int count = 0; 
            Queue<Vertex> q = new Queue<Vertex>();
            HashSet<Vertex> visitedHS = new HashSet<Vertex>();
            visitedHS.Add(startNode);
            q.Enqueue(startNode); 

            UpdateVertexStack(ref q, ref visitedHS);
            visitedHS.Clear();

            // find the transpose of the graph
            TransposeGraph(startNode, ref visitedHS);
            visitedHS.Clear();

            // now for each popped node, do a DFS and update the count 
            // if loop detected, count += 1 else, count += number of vertices
            var node = q.Dequeue();
            while (node != null)
            {
                Stack<Vertex> st = new Stack<Vertex>();
                st.Push(node);
                visitedHS.Add(node);
                DFS(ref st, ref visitedHS);
                count++;

                // get the next unvisited node
                while (visitedHS.Contains(node = q.Dequeue()) == true) ;
            }

            return count; 
        }

        private static void TransposeGraph(Vertex startNode, ref HashSet<Vertex> visitedHS, Vertex parent = null)
        {
            if (visitedHS.Contains(startNode) || startNode.next == null) // reached the end
            {
                visitedHS.Add(startNode);
                startNode.next.Add(parent);
                parent.next.Remove(startNode);
            }
            else
            {
                visitedHS.Add(startNode);
                foreach (var child in startNode.next)
                {
                    TransposeGraph(child, ref visitedHS, startNode);
                    child.next.Add(startNode);
                    startNode.next.Remove(child);
                }                
            }                        
        }

        static void DFS(ref Stack<Vertex> st, ref HashSet<Vertex> visitedHS)
        {
            Vertex v = st.Peek();

            foreach (var item in v.next)
            {
                if (visitedHS.Contains(item))
                    continue;

                visitedHS.Add(item);
                st.Push(item);
                DFS(ref st, ref visitedHS);
            }

        }

        static void UpdateVertexStack(ref Queue<Vertex> q, ref HashSet<Vertex> visitedHS)
        {
            Vertex v = q.Peek(); 

            foreach(var item in v.next)
            {
                if (visitedHS.Contains(item))
                    continue;
                
                visitedHS.Add(item);
                q.Enqueue(item);
                UpdateVertexStack(ref q, ref visitedHS);
            }
        }

       



    }
}
