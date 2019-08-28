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
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();
        vida_player = player_script.my_life;
        original = tiempo;
        Movimiento.Is_playable = true; // El game manager se encargara de eso luego
    }


    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable == true) {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                vida_player = 0;
                tiempo = original;
                player_script.muerte();

            }
            Tiemp_ui.text = "Tiempo: " + tiempo;
        }
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(repanwtime);

        
    }

    public float time_rise;
    public void aumenta_tiempo() {
        tiempo += time_rise;
    }
}
