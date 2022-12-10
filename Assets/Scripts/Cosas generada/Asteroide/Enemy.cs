using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public Nave naveScript;
    GameObject naveGo;
    float posz;

    GameObject gamemanager;
    GameManager gamemanagerScript;
    public GameObject explosion;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController");
        gamemanagerScript = gamemanager.GetComponent<GameManager>();

        Destroy(gameObject,30);

        naveGo = GameObject.FindGameObjectWithTag("Player");
        naveScript = naveGo.GetComponent<Nave>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        
        //si pasa de la nave explota y resta vida
        posz = transform.localPosition.z;
        if (posz <= -9.969)
        {
            naveScript.RestHealth(damage);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            naveScript.RestHealth(damage);
            Destroy(gameObject);
            Instantiate(explosion, transform.localPosition, transform.rotation);
        }
    }

    public void DañoRecibido(int danyo)
    {
        if (health <= danyo)
        {
            Destroy(gameObject);
            gamemanagerScript.Score(10);
            // creamos explosion
            Instantiate(explosion, transform.localPosition, transform.rotation);
        } else
        {
            health -=  danyo;
        }
    }
}
