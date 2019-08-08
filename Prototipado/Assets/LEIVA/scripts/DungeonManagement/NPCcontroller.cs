using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    public float patrolTime = 10;
    public float aggroRange = 10;
    public Transform[] waypoints;

    int index;

    float speed, agentSpeed;
    
    Transform player;
    
    NavMeshAgent agent;
    
    private void Awake() {
        agent=GetComponent<NavMeshAgent>();
        agentSpeed = agent.speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0,waypoints.Length);

        InvokeRepeating("Tick", 0, 0.5f);

        if (waypoints.Length > 0) {
            InvokeRepeating("Patrol", Random.Range(0, patrolTime), patrolTime);
        }
    }
    void Update() {
        speed = Mathf.Lerp(speed, agent.velocity.magnitude,Time.deltaTime * 10);
    }
    void Patrol() {
        index = index == waypoints.Length -  1 ? 0 : index + 1; // regresa a 0 si es ultimo, suma 1 si no es el ultimo
    }
    void Tick() {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;
        if (player != null && Vector3.Distance(transform.position,player.position) < aggroRange) {
            agent.speed = agentSpeed;
            agent.destination= player.position;
        
        }
    }
    private void OnDrawGizmos() { 
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
