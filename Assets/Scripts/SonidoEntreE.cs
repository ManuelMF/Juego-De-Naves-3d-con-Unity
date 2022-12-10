using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoEntreE : MonoBehaviour
{
    // hacer una clase singlenton
    private static SonidoEntreE _instance;

    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            //hacemos que no se destruya
            DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }
}
