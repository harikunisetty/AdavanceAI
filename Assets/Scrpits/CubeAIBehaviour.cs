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
    [SerializeField] Transform targetATrans, targetBTrans;
    private Node.Status treeStatus = Node.Status.Running;
    private AgentState agentState = AgentState.Idle;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();

        Sequence getItem = new Sequence("Get Key");
        Leaf goToKeyPosition = new Leaf("Go To Key", GoToKeyObject);
        Leaf escape = new Leaf("Escape", GoToHideOut);

        getItem.Addchild(goToKeyPosition);
        getItem.Addchild(escape);
        tree.Addchild(getItem);


        tree.PrintTree();
       /* agent.SetDestination(targetATrans.position);*/
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
