using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    public float patrolTime = 10;
    public float aggroRange = 10;
    public float atackRange;
    public Transform[] waypoints;
    public float Atack_Interval;
    Animator mis_animaciones;
    public float agentSpeed;
    public bool is_atacking;
    public bool canHarm;
    public float HarmTime;
    float normalSPEED;
    int index;
    bool can_do=true;
    Transform player;
    
    NavMeshAgent agent;
    
    private void Start() {
        agent =GetComponent<NavMeshAgent>();
        canHarm = false;
        mis_animaciones = gameObject.GetComponent<Animator>();
        mis_animaciones.SetBool("Atack1", false);
        agentSpeed = agent.speed;
        is_atacking = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0,waypoints.Length);
        normalSPEED = agentSpeed;
        InvokeRepeating("Tick", 0, 0.5f);
        canBeHarm = true;
        if (waypoints.Length > 0) {
            InvokeRepeating("Patrol", Random.Range(0, patrolTime), patrolTime);
        }
    }
    void Update() {
        if (can_do) {
            atacar_player(); //Sera algo lento al atacar al enemigo
            //print(agentSpeed);
           // print(normalSPEED);
        }
    }
    void atacar_player() {
        if (Movimiento.Is_playable && Vector3.Distance(transform.position,player.position) < atackRange && is_atacking ==false) {
            agentSpeed = 0;
            is_atacking = true;
            mis_animaciones.SetBool("Atack1",true);
            StartCoroutine("espera2");
        }
    }
    IEnumerator espera2() {
        yield return new WaitForSeconds(HarmTime); //Evita que el jugador haga la animacion de dolor antes de recibir el golpe
        canHarm = true;
    }
    public void revert() {
        mis_animaciones.SetBool("Atack1", false);
        canHarm = false;
        StartCoroutine("espera");//Antes de activar la animacion se asegura que el jugador este y que no se interrumpa animacion
        agentSpeed = normalSPEED;
    }
    void Patrol() {
        index = index == waypoints.Length -  1 ? 0 : index + 1; // regresa a 0 si es ultimo, suma 1 si no es el ultimo
    }//Cambia a donde ira
    void Tick() { //mira y sigue al player si est acerca
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;
        if (player != null && Vector3.Distance(transform.position,player.position) < aggroRange) {
            agent.speed = agentSpeed; //Aumenta vel para seguir player
            agent.destination= player.position;
            transform.LookAt(player.position);
           
        }
    }
    public bool canBeHarm;
    public float atack_recovery_time;
    public void cancelar_acciones(bool willDie) {
        can_do = false;
        if (willDie)
        {
            agent.isStopped = true;
            CancelInvoke();
            mis_animaciones.SetTrigger("Is_Death");
        }
        else if(canBeHarm){
            canBeHarm = false;
            mis_animaciones.SetTrigger("Is_Hurt");
            mis_animaciones.SetBool("Atack1", false);
            canHarm = false;
            agentSpeed = 0;
        }
     
    }
    public void restaurar() {
        can_do = true; //Restaura velocidad y sigue con sus actividades nomales
        agentSpeed = normalSPEED;
        StartCoroutine("espera3");

    }
    IEnumerator espera3()
    {
        yield return new WaitForSeconds(atack_recovery_time); // Tiempo que espera para continuar atacando
        canBeHarm = true;

    }
    IEnumerator espera()
    { 
            yield return new WaitForSeconds(Atack_Interval); // Tiempo que espera para continuar atacando
            is_atacking = false;
            
    }
    private void OnDrawGizmos() { 
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
   private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, atackRange);
    }


}
