using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    Enemy EnemyScript;
    public GameObject enemy;
    public int damage;
    public GameObject explosion;
    
    GameObject naveGo;
    Nave naveScript;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5);
        naveGo = GameObject.FindGameObjectWithTag("Player");
        naveScript = naveGo.GetComponent<Nave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            EnemyScript = other.GetComponent<Enemy>();
            EnemyScript.DañoRecibido(damage);
            Destroy(gameObject);
            Instantiate(explosion, other.transform.position , other.transform.rotation);
        }

        if (other.gameObject.tag == "Player")
        {
            naveScript.RestHealth(damage);
            Destroy(gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }
}
