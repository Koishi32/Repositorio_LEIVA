using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool boos_victory;
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
        boos_victory = false; // aun no le gana al boos
    }

    void checar_tiempo() {
            if (Movimiento.Is_playable)
            {
                tiempo -= Time.deltaTime;
                if (tiempo <= 0)
                {
                    // player_script.my_life = 0;
                    //tiempo = original;
                    player_script.muerte();

				//se agrega contador de tiempo para despues cambiar a pantalla de derrota
				StartCoroutine("pantallaPierde");
                    jugador.GetComponent<Animator>().ResetTrigger("back");
                    mooriste.gameObject.SetActive(true);
                }
			Tiemp_ui.text = "Tiempo: " + tiempo.ToString("f0") ;
            }
            else if (tiempo > 0)
            {
                StartCoroutine("espera");
            }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!boos_victory)
        {
            checar_tiempo();
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
        jugador.GetComponent<PerDameage>().lives = true;
        //jugador.GetComponent<Damageable>().vida = vida_anterios;
        Movimiento.Is_playable = true;
    }

	IEnumerator pantallaPierde()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(3);
	}

    public float time_rise;
    public void aumenta_tiempo() {
        tiempo += time_rise;
    }
}
