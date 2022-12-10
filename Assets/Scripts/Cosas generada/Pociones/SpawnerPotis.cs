using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPotis : MonoBehaviour
{

     public GameObject Pocion;
     public float start;
     public float delay;

     public GameObject[] potis;
     public int pocion;
     public int potisLength;

     public float randomX;
     public float randomY;

     public bool respawnear = true;

    void Start()
    {
          
         InvokeRepeating("CrearPocion", start, delay);
        potisLength = potis.Length;
    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.R) && respawnear == true)
        {
            CancelInvoke("CrearEnemigo");
            respawnear = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && respawnear == false)
        {
            InvokeRepeating("CrearEnemigo", start, delay);
            respawnear = true;
        }*/
    }

    public void CrearPocion()
    {
        randomX = Random.Range(-7f, 7f);
        randomY = Random.Range(-4f, 4f);

        float porcentaje = Random.Range(0f, 1f);
        
        if (0.50f > porcentaje )
        {
            Pocion = potis[0];
            pocion = 0;
        } else if (0.50f <= porcentaje)
        {
            Pocion = potis[1];
            pocion = 1;
        } 

        Instantiate(Pocion, new Vector3(randomX, randomY, transform.localPosition.z), Pocion.transform.rotation);
    }
}
