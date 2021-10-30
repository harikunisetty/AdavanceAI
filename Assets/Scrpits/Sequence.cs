using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence(string _name)
    {
        name = _name;
    }

    public override Status Process()
    {
        Status childStatus = Children[currentChild].Process();

        if (childStatus == Status.Running)
            return Status.Running;
        if (childStatus == Status.Failure)
            return childStatus;

        currentChild++;
        if (currentChild >= Children.Count)
        {
            currentChild = 0;
            return Status.sucess;
        }

        return Status.Running;
    }
}