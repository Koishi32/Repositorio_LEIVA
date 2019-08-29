using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timeManager : MonoBehaviour
{
    public float tiempo;
    public Text Tiemp_ui;
    public Movimiento player_script;
    float vida_player;
    float original;
    public float repanwtime = 3;
    public GameObject jugador;
    public Text mooriste;
    public Transform respan_point;
    float vida_anterios;
    float velAnt;
    // Start is called before the first frame update
    void Start()
    {
        mooriste.gameObject.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player");
        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
       // vida_player = player_script.my_life;
        velAnt = player_script.get_vel();
        original = tiempo;
        Movimiento.Is_playable = true; // El game manager se encargara de eso luego
        vida_anterios = player_script.my_life;
    }


    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable == true) {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                player_script.my_life = 0;
                //tiempo = original;
                player_script.muerte();
                mooriste.gameObject.SetActive(true);
            }
            Tiemp_ui.text = "Tiempo: " + tiempo;
        }
        else if(tiempo>0)
        {
            StartCoroutine("espera");
        }
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(repanwtime);
        jugador.transform.position = respan_point.position;
        player_script.my_life = vida_anterios;
        player_script.vel = velAnt;
        jugador.GetComponent<Animator>().ResetTrigger("Is_Hurt");
        jugador.GetComponent<Animator>().SetTrigger("back");
        jugador.GetComponent<ControlInput>().Reset();
        jugador.GetComponent<Damageable>().lives = true;
        Movimiento.Is_playable = true;
    }

    public float time_rise;
    public void aumenta_tiempo() {
        tiempo += time_rise;
    }
}
