using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : MonoBehaviour
{
    public float speed;
    Nave naveScript;
    public GameObject naveGo;
    public int sumHeald;
    public int sumArmor;

    // Start is called before the first frame update
    void Start()
    {
        naveGo = GameObject.FindGameObjectWithTag("Player");
        naveScript = naveGo.GetComponent<Nave>();
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    //si choca con la nave sumara la vida o activara un escudo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "PocionVida") naveScript.sumHealth(sumHeald);
            if (gameObject.tag == "PocionEscudo") naveScript.cogerPocionArmor(sumArmor);

            Destroy(gameObject);
        }
    }
}
