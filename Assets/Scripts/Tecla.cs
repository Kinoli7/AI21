using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla : MonoBehaviour
{
    public AudioClip nota;
    public string respuesta;
    public string tecla;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            transform.Rotate(-15, 0, 0, Space.Self);
        }
        else if (Input.GetKeyUp(tecla))
        {
            transform.Rotate(15, 0, 0, Space.Self);
        }
    }

}
