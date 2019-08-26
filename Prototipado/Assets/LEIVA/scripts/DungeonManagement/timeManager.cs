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
    // Start is called before the first frame update
    void Start()
    {
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
                Movimiento.Is_playable = false;
                player_script.muerte();
            }
            Tiemp_ui.text = "Tiempo: " + tiempo;
        }
    }
}
