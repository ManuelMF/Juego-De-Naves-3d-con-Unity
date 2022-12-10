using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    GameObject gamemanager;
    GameManager gamemanagerScript;
    Bullet bulletScript;
    public GameObject explosion;

    //movimiento
    public float movimientomaxX;
    public float movimientomaxY;
    public float rotMax;
    public float PosX;
    public float PosY;
    Boolean moverderecha = true;
    Boolean moverArriba = true;
    int repsMovLado;
    int repsMovArriba;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        gamemanagerScript = gamemanager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //movimiento 
        //arriba abajo  entra si ya a tocado dos veces un lado
        if (repsMovLado == 1)
        {
            // si y es mas pequeño que y max y se esta moviendo para arriba entra
            if (transform.localPosition.y < movimientomaxY && moverArriba)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            // si y es mas grande que el movimiento max de y en - entra
            else if (transform.localPosition.y > -movimientomaxY)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                moverArriba = false;
                // si toca el max
                if (transform.localPosition.y < -movimientomaxY)
                {
                    //le decimos que mueva arriba
                    moverArriba = true;
                    repsMovArriba++;
                    // si ya toco dos veces arriba va al lado
                    if (repsMovArriba == 1) repsMovLado = 0;   
                }
            }
        }
        //movimiento de lados
        else
        {   // hace lo mismo que arriba
            if (transform.localPosition.x < movimientomaxX && moverderecha)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (transform.localPosition.x > -movimientomaxX)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                moverderecha = false;
                // si toca la izquierda suma un lado y va a la deracha
                if (transform.localPosition.x < -movimientomaxX)
                {
                    moverderecha = true;
                    repsMovLado++;
                }
            }
        }
        

        
    }
    //cuanto toca una bala
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletScript = other.GetComponent<Bullet>();
            health = health - bulletScript.damage;
            Destroy(other.gameObject);
            gamemanagerScript.PonerVidaBoss(health);
            Instantiate(explosion, other.transform.position, other.transform.rotation);

        }
    }
}
