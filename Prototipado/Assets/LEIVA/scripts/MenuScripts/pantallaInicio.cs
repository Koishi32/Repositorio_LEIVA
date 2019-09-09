using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pantallaInicio : MonoBehaviour
{
	public int stateForImages = 0;
	public Image imagen1, imagen2, imagen3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
		{
			stateForImages++;
			if (stateForImages == 1)
			{
				imagen1.enabled = false;

			}

			if (stateForImages == 2)
			{
				imagen2.enabled = false;
			}

			if (stateForImages == 3)
			{
				imagen3.enabled = false;
			}

			if (stateForImages == 4)
			{
				SceneManager.LoadScene(0);
			}
		}
	}
}
