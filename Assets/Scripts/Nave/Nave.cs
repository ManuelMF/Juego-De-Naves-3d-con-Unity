using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public float PosXMax;
    public float PosYMax;
    public float RotMax;

    public int health;
    public int armor;
    public GameObject escudo;

    public GameObject gamemanager;
    GameManager gamemanagerScript;

    public GameObject herida;
    
    void Start()
    {
        gamemanagerScript = gamemanager.GetComponent<GameManager>();  
        
    }

    
    void Update()
    {
        PosX = Input.GetAxis("Horizontal");
        PosY = Input.GetAxis("Vertical");
        transform.localPosition = new Vector3(PosX * PosXMax  , PosY * PosYMax , 0);
        transform.eulerAngles = new Vector3(0, 0, PosX * RotMax);


        //si la armadura esta en negativo quitaremos el desgasteç
        if (armor < 0) CancelInvoke("desgasteArmadura");
    }

    public void RestHealth(int Damage)
    {  // mira si tiene armadura
        if (armor > 0)
        {
            //resta armadura
            armor = armor - Damage;
            // si no queda armadura quita el panel
            if (armor <= 0) gamemanagerScript.ocultalPanelArmadura();
            // si aun queda armadura actualiza el panel armadura
            if (armor > 0) gamemanagerScript.PonerArmorConPocion(armor);
            // quitamos lo que quede de daño armor es negativo -5 + 6 = 1
            if (armor < 0) health = armor + health;
        }
        else health -= Damage;
        
        //te pone la vida en la pantalla y activa la herida
        gamemanagerScript.PonerVida(health);
        
        herir();

    }

    public void sumHealth(int sum)
    {
        health += sum;
        if (health > 100) health = 100;
        gamemanagerScript.PonerVidaConPocion(health);
    }
    //coge una pocion de armadura
    public void cogerPocionArmor(int cogerArmor)
    {
        armor = cogerArmor;
        gamemanagerScript.PonerArmorConPocion(cogerArmor);
        InvokeRepeating("desgasteArmadura", 0, 0.3f);

        Instantiate(escudo, this.transform.position, this.transform.rotation);
    }

    //cuenta el tiempo que estas herido
    public void herir()
    {
        UsingYield(3);

    }
    IEnumerator UsingYield(int seconds)
    {
        herida.SetActive(true);

        yield return new WaitForSeconds(seconds);
        herida.SetActive(false);
    }

    public void desgasteArmadura() 
    {
        armor = armor - 1;

        if (armor <= 0) gamemanagerScript.ocultalPanelArmadura();
        if (armor > 0) gamemanagerScript.PonerArmorConPocion(armor);
    }

}
