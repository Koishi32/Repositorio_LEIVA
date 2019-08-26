using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    public float patrolTime = 10;
    public float aggroRange = 10;
    public Transform[] waypoints;
    public float Atack_Interval;
    Animator mis_animaciones;
    int index;
    bool is_atacking;
    float speed, agentSpeed;
    
    Transform player;
    
    NavMeshAgent agent;
    
    private void Awake() {
        agent =GetComponent<NavMeshAgent>();
        mis_animaciones = gameObject.GetComponent<Animator>();
        mis_animaciones.SetBool("Atack1", false);
        agentSpeed = agent.speed;
        is_atacking = false;
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
    void atacar_player() {
        if (Vector3.Distance(transform.position,player.position) < 0.5 && is_atacking ==false) {
            mis_animaciones.SetBool("Atack1",true);
            StartCoroutine("espera");
        }
    }
    public void revert() {
        mis_animaciones.SetBool("Atack1", false);
    }
    void Patrol() {
        index = index == waypoints.Length -  1 ? 0 : index + 1; // regresa a 0 si es ultimo, suma 1 si no es el ultimo
    }//Cambia a donde ira
    void Tick() {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;
        if (player != null && Vector3.Distance(transform.position,player.position) < aggroRange) {
            agent.speed = agentSpeed;
            agent.destination= player.position;
            transform.LookAt(player.position);
            atacar_player(); //Sera algo lento al atacar al enemigo
        }
    }
    IEnumerator espera()
    {
        if (is_atacking == false)
        {
            is_atacking = true;
        }
        yield return new WaitForSeconds(Atack_Interval); // Tiempo que espera para continuar combo tiene que ser mas corto que el ataque
        is_atacking = false;
    }
    private void OnDrawGizmos() { 
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
