using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarArmas : MonoBehaviour
{
    public GameObject[] armas;

    void Start()
    {
        desactivarArmas();
        activarArma(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            desactivarArmas();
            activarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            desactivarArmas();
            activarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            desactivarArmas();
            activarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            desactivarArmas();
            activarArma(3);
        }

    }

    
    void activarArma(int arma)
    {
        armas[arma].SetActive(true);
    }
        

    void desactivarArmas()
    {
        foreach (GameObject arma in armas)
        {
            arma.SetActive(false);
        }
    }
    
}
