using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum Status
    {
        Runing,sucess,Failure
    }
    public Status status;

    public List<Node> Children = new List<Node>();

    public int currentChild = 0;

    public string name;
    public Node() { }
    public Node(string _name)
    {
        name = _name;
    } 
    public void Addchild(Node nodeValue)
    {
        Children.Add(nodeValue);
    }
}   
