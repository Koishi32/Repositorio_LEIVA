using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    public float tiempo;
    public Text Tiemp_ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        Tiemp_ui.text = "Tiempo: "+tiempo;
    }
}
