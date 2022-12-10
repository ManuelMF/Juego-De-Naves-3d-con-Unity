using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform disparador;
    public float delay;

    public GameObject weapon;
    int iniD;

    public GameObject audioBalaGo;
    AudioBalaMetralleta audioControlScript;

    void Start()
    {
        iniD = 1;

        //audioBalaGo = GameObject.FindGameObjectWithTag("AudioBala");
        audioControlScript = audioBalaGo.GetComponent<AudioBalaMetralleta>();
    }

    void Update()
    {
        if (iniD == 1)
        {
            Debug.Log("entra");
            InvokeRepeating("CrearBala", 0, delay);
            iniD = 0;
        }
    }

    public void CrearBala()
    {
        Rigidbody rocketInstance;
        rocketInstance = Instantiate(bullet, disparador.transform.position, bullet.transform.rotation) as Rigidbody;
        rocketInstance.AddForce(disparador.forward * 5000);
        //audioControlScript.AudioDisparar();
    }
}
