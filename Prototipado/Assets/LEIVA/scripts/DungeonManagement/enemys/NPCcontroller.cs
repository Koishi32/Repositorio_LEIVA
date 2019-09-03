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
    public bool is_atacking;
    public bool canHarm;
    public float HarmTime;
    float normalSPEED;
    int index;
    bool can_do=true; // Permite que el Enemigo haga lo que sea , usar para muerte 
    Transform player;
    
    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        canHarm = false;
        mis_animaciones = gameObject.GetComponent<Animator>();
        mis_animaciones.SetBool("Atack1", false);
        is_atacking = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length);
        normalSPEED = get_Agent_Speed();
        invocando();
        canBeHarm = true;
        
    }
    float get_Agent_Speed() {
        return agent.speed;
    }
    void invocando() { // rutinas para detectar al jugador y cambiar localizaciones
        InvokeRepeating("Tick", 0, 0.5f);
        if (waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", Random.Range(0, patrolTime), patrolTime);
        }
    } 
    void Update() {
        if (can_do)
        {
            atacar_player();
        }
    }
    void atacar_player() {
        if (Movimiento.Is_playable && Vector3.Distance(transform.position, player.position) < atackRange && !is_atacking) {
            agent.speed = 0;
            is_atacking = true;
            mis_animaciones.SetBool("Atack1", true); // Inicia ataque
            StartCoroutine("espera2"); //Countdown para permitir daño al jugador
        } else if (Vector3.Distance(transform.position, player.position) > atackRange) {
            agent.speed = normalSPEED;
        }
    }
    void elegir_atack() { // se pueden meter mas cases para mas animaciones
        float opcion =Mathf.RoundToInt( Random.Range(0, 1));
        switch (opcion) {
            case 0:
                //ani1 
            break;
            case 1:
                //ani2 solo necesitan lanzar el evento restaurar
            break;
        }
    }
    IEnumerator espera2() {
        yield return new WaitForSeconds(HarmTime); //Evita que el jugador haga la animacion de dolor antes de recibir el golpe
        canHarm = true; // el jugador puede recibir daño
    }
    public void revert() { //Acaba la animacion de ataque 
        mis_animaciones.SetBool("Atack1", false);
        canHarm = false;
        StartCoroutine("espera");//Espera antes de que de otro golpe
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(Atack_Interval); // Tiempo que espera para continuar atacando
        is_atacking = false;
    }

    /// <summary>
    /// Esta parte consiste de seguir al player si esta en rango de ser seguido ademas se cambian las localizaciones por las que ira explorando la IA
    /// </summary>
    void Patrol() {
        index = index == waypoints.Length -  1 ? 0 : index + 1; // regresa a 0 si es ultimo, suma 1 si no es el ultimo
    }//Cambia a donde ira

    public float Persuit_Vel_Reduction;//velocidad con la que persigue al jugador

    void Tick() { //mira y sigue al player si est acerca
        agent.destination = waypoints[index].position;
        agent.speed = normalSPEED / Persuit_Vel_Reduction;
        if (player != null && Vector3.Distance(transform.position,player.position) < aggroRange) {
            agent.speed = normalSPEED; //Aumenta vel para seguir player
            agent.destination= player.position;
            transform.LookAt(player.position);
        }
    }
    /// <summary>
    /// Esta parte se concentra en que el enemigo reciba un stunt
    /// </summary>
    public bool canBeHarm;
    public float atack_recovery_time;

    public void cancelar_acciones(bool willDie) {
        can_do = false;
        if (willDie)
        {
            CancelInvoke();
            can_do = false; // ya no ataca al enemigo
            agent.isStopped = true; //Detiene el agente, se supone 
            mis_animaciones.SetTrigger("Is_Death"); //Al finalizar la animacion le indicara a dameageable que muera
        }
        else if(canBeHarm){
            canBeHarm = false;
            canHarm = false;
            mis_animaciones.SetBool("Atack1", false);
            mis_animaciones.SetTrigger("Is_Hurt"); //toca la animacion de lastimado
            agent.speed = 0; //Detiene la velocidad para que se haga la animacion
            CancelInvoke(); // se cancelan los conportamiento por si acaso
        }
     
    }

    public void restaurar()
    { // la animacion de dolor ha terminado canBeHarm = false;
      // canBeHarm = true;
        print("Acabo la animacion");
        can_do = true; //Restaura velocidad y sigue con sus actividades nomales
        invocando(); // reiniciar las rutinas
        agent.speed = normalSPEED; // restaura la velocidad
        StartCoroutine("espera3"); // Countdown para que reciva daño y haga la animacion otra vez

    }

    IEnumerator espera3()
    {
        yield return new WaitForSeconds(atack_recovery_time); // Tiempo que espera para continuar atacando
        canBeHarm = true;

    }
    //Dibuja el rango por el que empezara a seguir al jugador 
    private void OnDrawGizmos() { 
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
