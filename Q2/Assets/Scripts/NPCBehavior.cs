using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Character))]
public class NPCBehavior : MonoBehaviour
{
    private Animator anim;
    private LineRenderer lr;
    private NavMeshAgent agent;
    private Character character;
    public GameObject[] waypoints;
    private Vector3 currentPosition;
    private Vector3 currentWaypoint;
    private float currentDistance = 0;

    private int waypointInd;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("NPCState", 0);

        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.updatePosition = true;
        agent.updateRotation = false;

        character = GetComponent<Character>();

        waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        waypointInd = Random.Range(0, waypoints.Length);
        
        anim.SetInteger("NPCState", 1);  // Walk
    }

    // Update is called once per frame
    private void Update()
    {
        if (!agent.enabled && anim.GetInteger("NPCState") != 2) // NPC not dead
        {
            agent.enabled = true;
            anim.SetInteger("NPCState", 1);  // Walk
        }

        else if (agent.enabled)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        currentWaypoint = waypoints[waypointInd].transform.position;
        currentDistance = Vector3.Distance(currentPosition, currentWaypoint);
        currentPosition = this.transform.position;
        if (currentDistance >= 15)
        {
            agent.SetDestination(currentWaypoint);
            character.Move(agent.desiredVelocity);
        }
        else if(currentDistance <= 15)
        {
            waypointInd = Random.Range(0, waypoints.Length);
        }
        else
        {
            character.Move(Vector3.zero);
        }

        lr.positionCount = agent.path.corners.Length;
        for (int i = 0; i < agent.path.corners.Length; i++)
        {
            lr.SetPosition(i, agent.path.corners[i]);
        }
    }
}
