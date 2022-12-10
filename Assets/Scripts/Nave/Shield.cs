using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    GameObject naveGo;
    Nave naveScript;

    void Start()
    {
        naveGo = GameObject.FindGameObjectWithTag("Player");
        naveScript = naveGo.GetComponent<Nave>();
    }

    void Update()
    {
        if (naveScript.armor <= 0) this.gameObject.SetActive(false);
        transform.localPosition = new Vector3(naveGo.transform.position.x, naveGo.transform.position.y, -1);
    }
}
