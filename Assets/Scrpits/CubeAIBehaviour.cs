using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeAIBehaviour : MonoBehaviour
{
    public BehaviourTree tree;
    public enum AgentState { Idle, Working };

    [Header("Unity AI")]
    private NavMeshAgent agent;
    [SerializeField] Transform targetATrans, targetBTrans,frontDoor,backDoor;
    private Node.Status treeStatus = Node.Status.Running;
    private AgentState agentState = AgentState.Idle;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();

        Sequence getItem = new Sequence("Get Key");
        Leaf goToFrontDoor = new Leaf("go To Front Door", GoToFrontDoor);
        Leaf goToBackDoor = new Leaf("go To Front Door", GoToBackDoor);
        Leaf goToKeyPosition = new Leaf("Go To Key", GoToKeyObject);
        Leaf escape = new Leaf("Escape", GoToHideOut);

        Selector doorWay = new Selector("Door Way");
        doorWay.Addchild(goToBackDoor);
        doorWay.Addchild(goToFrontDoor);

        getItem.Addchild(goToKeyPosition);
        getItem.Addchild(goToBackDoor);
        getItem.Addchild(escape);
        getItem.Addchild(doorWay);
        tree.Addchild(getItem);


        tree.PrintTree();
       /* agent.SetDestination(targetATrans.position);*/
    }
    public Node.Status GoToFrontDoor()
    {
        return GoToLocation(frontDoor.position);
    }
    public Node.Status GoToBackDoor()
    {
        return GoToLocation(backDoor.position);
    }   
    public Node.Status GoToKeyObject()
    {
        return GoToLocation(targetATrans.position);
    }

    public Node.Status GoToHideOut()
    {
        return GoToLocation(targetBTrans.position);
    }

    void Update()
    {
        if (treeStatus == Node.Status.Running)
            treeStatus = tree.Process();
    }

    private Node.Status GoToLocation(Vector3 destinationPosition)
    {
        float distanceToTarget = Vector3.Distance(destinationPosition, this.transform.position);

        if (agentState == AgentState.Idle)
        {
            agent.SetDestination(destinationPosition);
            agentState = AgentState.Working;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destinationPosition) >= 2)
        {
            agentState = AgentState.Idle;

            return Node.Status.Failure;
        }
        else if (distanceToTarget < 2)
        {
            agentState = AgentState.Idle;

            return Node.Status.sucess;
        }

        return Node.Status.Running;
    }
}
