using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public OpponentController opponentController;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public object Go { get; private set; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<OpponentController>().actualAngle = transform.rotation.y;
        StartCoroutine(opponentController.Rotate());
    }


    public void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
         
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

}