using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

namespace TreeGraph
{
    class Graph
    {
        static void Main1(string[] args)
        {
            Graph<string> web = new Graph<string>();
            web.AddNode("Privacy.htm");
            web.AddNode("People.aspx");
            web.AddNode("About.htm");
            web.AddNode("Index.htm");
            web.AddNode("Products.aspx");
            web.AddNode("Contact.aspx");

            web.AddDirectedEdge(new GraphNode<string>("People.aspx"), new GraphNode<string>("Privacy.htm"),1);  // People -> Privacy

            web.AddDirectedEdge(new GraphNode<string>("Privacy.htm"), new GraphNode<string>("Index.htm"),2);    // Privacy -> Index
            web.AddDirectedEdge(new GraphNode<string>("Privacy.htm"), new GraphNode<string>("About.htm"),3);    // Privacy -> About

            web.AddDirectedEdge(new GraphNode<string>("About.htm"), new GraphNode<string>("Privacy.htm"),4);    // About -> Privacy
            web.AddDirectedEdge(new GraphNode<string>("About.htm"), new GraphNode<string>("People.aspx"),5);    // About -> People
            web.AddDirectedEdge(new GraphNode<string>("About.htm"), new GraphNode<string>("Contact.aspx"),6);   // About -> Contact

            web.AddDirectedEdge(new GraphNode<string>("Index.htm"), new GraphNode<string>("About.htm"),7);      // Index -> About
            web.AddDirectedEdge(new GraphNode<string>("Index.htm"), new GraphNode<string>("Contact.aspx"),8);   // Index -> Contacts
            web.AddDirectedEdge(new GraphNode<string>("Index.htm"), new GraphNode<string>("Products.aspx"),9);  // Index -> Products

            web.AddDirectedEdge(new GraphNode<string>("Products.aspx"), new GraphNode<string>("Index.htm"),10);  // Products -> Index
            web.AddDirectedEdge(new GraphNode<string>("Products.aspx"), new GraphNode<string>("People.aspx"),11);// Products -> People


        }
    }
    //a base Node class that can be extended to meet the needs of a binary tree node through 
    //inheritance. The base Node  class represents a node in a general tree, one whose nodes can 
    //have an arbitrary number of children.
    public class Node<T>
    {
        // Private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
    }
    public class Graph<T> //: IEnumerable<T>
    {
        private NodeList<T> nodeSet;

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new NodeList<T>();
            else
                this.nodeSet = nodeSet;
        }

        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            // adds a node to the graph
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public NodeList<T> Nodes
        {
            get
            {
                return nodeSet;
            }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }
    }


}
