using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();
    public Tick ProccessMethod;

    public Leaf() { }
    public Leaf(string _name, Tick _tick)
    {
        name = _name;
        ProccessMethod = _tick;
    }

    public override Status Process()
    {
        if (ProccessMethod != null)
            return ProccessMethod();
        else
            return Status.Failure;
    }
}
