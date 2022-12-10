using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform disparador;
    public float delay;

    //Para que no se haga una metralleta infinata y que pueda usar las 2 armas a la vez tengo que acceder al script de arma2 ya que al cambiar de arma entro en arma1 y no lo modifica
    Weapon weapon2Script;
    public GameObject weapon;

    GameObject audioBalaGo;
    AudioBalaMetralleta audioControlScript;

    void Start()
    {
        audioBalaGo = GameObject.FindGameObjectWithTag("AudioBala");
        audioControlScript = audioBalaGo.GetComponent<AudioBalaMetralleta>();
    }

    void Update()
    {
        // Arma1
        if (Input.GetButtonDown("Fire1") && disparador.gameObject.tag == "Arma1")
        {
            CrearBala();
        }

        //Arma2
        else if (Input.GetButtonDown("Fire1") && disparador.gameObject.tag == "Arma2")         
        {
            InvokeRepeating("CrearBala", 0, delay);
            
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            weapon2Script = weapon.GetComponent<Weapon>();
            weapon2Script.CancelInvoke("CrearBala");
        }
        
    }

   public void CrearBala()
    {
        Rigidbody rocketInstance;
        rocketInstance = Instantiate(bullet, disparador.transform.position, bullet.transform.rotation) as Rigidbody;
        rocketInstance.AddForce(disparador.forward * 5000);
        audioControlScript.AudioDisparar();
    }
}
