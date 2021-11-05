using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector :Node
{
   public Selector(string _name)
    {
        name = _name;
    }
    public override Status Process()
    {
        Status childStatus = Children[currentChild].Process();

        if (childStatus == Status.Running)
        {
            return Status.Running;
        }
        if (childStatus == Status.sucess)
        {
            currentChild = 0;
            return Status.sucess;
        }
        currentChild++;

        if (currentChild >= Children.Count)
        {
            currentChild = 0;
            return Status.Failure;
        }
        return Status.sucess;
    }
}
