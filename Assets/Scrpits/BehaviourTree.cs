using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node
{
   public BehaviourTree()
    {
        name = "tree";
    }
    public BehaviourTree(string _name)
    {
        name=_name;
    }
    struct NodeLevel 
    {
        public int level;
        public Node node;
    }
    public override Status Process()
    {
        return Children[currentChild].Process();
    }
    public void PrintTree()
    {
        string treePrint = " ";

        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
        Node currentNode = this;

        nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

        while (nodeStack.Count!=0)
        {
            NodeLevel nextNode = nodeStack.Pop();
            treePrint += new string('-', nextNode.level) + nextNode.node.name + "\n";
            for (int i = nextNode.node.Children.Count - 1; i >= 0; i--)
            {
                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.Children[i] });
            }
        }
        Debug.Log(treePrint);
    }
}
