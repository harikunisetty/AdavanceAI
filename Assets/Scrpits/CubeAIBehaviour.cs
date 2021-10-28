using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeAIBehaviour : MonoBehaviour
{
    public BehaviourTree tree;
    [Header("Unity UI")]
    private NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();

        Node getItem = new Node("Get Key");
        Node goToKeyPosition = new Node("GO To Key");
        Node escap = new Node("Escape");


        getItem.Addchild(goToKeyPosition);
        getItem.Addchild(escap);
        tree.Addchild(getItem);

        tree.PrintTree();
        agent.SetDestination(targetTransform.position);
    }
    void Update()
    {
        
    }
}
