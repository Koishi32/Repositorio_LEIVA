using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnMenu : MonoBehaviour
{
    public float tiemposo_limit; // tiempo en segundos para que sea return
    public float tiempo_actual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(1);
		}

        if (Input.anyKey || Input.GetAxis("Mouse Y") !=0 || Input.GetAxis("Mouse X") !=0) {
            tiempo_actual = 0;
        }
        if (tiemposo_limit < tiempo_actual) {
            SceneManager.LoadScene(1); // se carga la escena del menu principal
        }
        tiempo_actual += Time.deltaTime;
    }
}
