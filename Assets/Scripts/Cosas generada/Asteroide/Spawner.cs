using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

     public GameObject Enemy;
     public float start;
     public float delay;

     public GameObject[] enemies;
     public int enemigo;
     public int enemigosLength;

     public float randomX;
     public float randomY;

     public bool respawnear = true;

    void Start()
    {
           delay = 2f;
         InvokeRepeating("CrearEnemigo", start, delay);
          enemigosLength = enemies.Length;
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

    public void CrearEnemigo()
    {
        randomX = Random.Range(-7f, 7f);
        randomY = Random.Range(-4f, 4f);

        float porcentaje = Random.Range(0f, 1f);
        
        if (0.20f > porcentaje )
        {
            Enemy = enemies[0];
            enemigo = 0;
        } else if (porcentaje < 0.40f)
        {
            Enemy = enemies[1];
            enemigo = 1;
        }
        else if (porcentaje < 0.60f)
        {
            Enemy = enemies[2];
            enemigo = 2;
        }
        else if (porcentaje < 0.80f)
        {
            Enemy = enemies[3];
            enemigo = 3;
        }else if (porcentaje > 0.80f)
        {
             Enemy = enemies[4];
            enemigo = 4;
        }
        

       
        Instantiate(Enemy, new Vector3(randomX, randomY, transform.localPosition.z), Enemy.transform.rotation);
    }
    
    public void pararSpawner()
    {
        CancelInvoke("CrearEnemigo");
    }
}
