using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text scorepanelwin;
    public TMP_Text scorepanellose;
    public Image vida;
    public Image vidaBoss;
    public GameObject PanelVidaBoss;
    public Image armor;
    public TMP_Text minutos;
    public TMP_Text segundos;
    public int scoreNecesarioParaWin;
    public GameObject herida;
    public GameObject panelWin;
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;
    public GameObject panelLose;
    public GameObject panelPausa;
    public GameObject panelAyuda;
    Boolean pausar = false;
    Boolean panelAyudabol = false;
    Boolean heriaActive = false;
    public GameObject bosss;

    public GameObject[] naves;

    float maxvida;
    float maxvidaBoss;
    public float maxArmor;
    public GameObject panelArmor;

    public GameObject spawner;
    Spawner SpawnerScript;
    public GameObject explosion;

    //despartar al iniciar el juego antes del start
    private void Awake()
    {
        foreach(GameObject nave in naves)
        {
            nave.SetActive(false);
        }
        int navenum = VG.SpaceShipNum;
        naves[navenum].SetActive(true);
    }

    void Start()
    {
        // siempre hay que poner esto para que no se quede guardado si cambio de pantalla
        Time.timeScale = 1f;


        //Buscar la vida total
        GameObject naveGo = GameObject.FindGameObjectWithTag("Player");
        Nave naveScript = naveGo.GetComponent<Nave>();
        maxvida = naveScript.health;
        
        //Timer cremos un invoke repeating  para que vaya anyadiendo segundos
        InvokeRepeating("anyadirSegundo", 0, 1);

        //cargamos el script spawn
        SpawnerScript = spawner.GetComponent<Spawner>();

        //hasta que carge el boss de verdad
       // maxvidaBoss = 300;
    }

    int number = 0;

    float secondsCounter = 0;
    float secondsToCount = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa();
        }

        //contamos x segundos para quitar herida
        if (heriaActive)
        {
            secondsCounter += Time.deltaTime;
            // si llega a un segundo entra y se pone en 0 
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                number++;
                // si llega a 4 segundos quitas la herida
                if (number == 4)
                {
                    herida.SetActive(false);
                    number = 0;
                }
            }
        }
        
    }

    public void Score(int valor)
    {
        int scoretotal = Int32.Parse(score.text);
        scoretotal += valor;
        score.text = scoretotal + "";
        scorepanellose.text = scoretotal + "";
        scorepanelwin.text = scoretotal + "";

        // Variables para cargar boss automaticamente "testeos"
        //VG.nivelAct = 3;
        //scoretotal = 300;
        //Cargar boss
        if ((VG.nivelAct == 3 && scoretotal >= 300) || (VG.nivelAct == 6 && scoretotal >= 500) )
        {
            cargarBoss();
        }
       
        //abrir win
        if (scoreNecesarioParaWin <= scoretotal)
        {
            panelWin.SetActive(true);
            win();
        }
    }
    // pone vida cuando te hieren y te activa la heridad
    public void PonerVida(int valor)
    {

        float valor2 = (float) valor;

        //si es 0 pierdes
        if (valor2 <= 0)
        {
            panelLose.SetActive(true);
            
            //eliminamos todo
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //destruimos los meteoriots
            foreach (GameObject enemy in enemies)
            {
                Debug.Log("2");
                Destroy(enemy);
                Instantiate(explosion, enemy.transform.localPosition, enemy.transform.rotation);
                SpawnerScript.pararSpawner();
            }
            Destroy(GameObject.FindGameObjectWithTag("Boss"));
        }
       
        vida.fillAmount = valor2 / maxvida ;

        // activamos la herida y activamos el contador para que se quite
        herida.SetActive(true);
        heriaActive = true;
        number = 0;
    }

    //suma vida
    public void PonerVidaConPocion(int valor)
    {
        float valor2 = (float) valor;

        vida.fillAmount = valor2 / maxvida;

    }

    public void PonerArmorConPocion(int valor)
    {
        float valor2 = (float)valor;

        armor.fillAmount = valor2 / maxArmor;

        //activamos el panel
        panelArmor.SetActive(true);

        //poner un invoke repetin que me reste ARMADURA

    }

    public void ocultalPanelArmadura()
    {
        panelArmor.SetActive(false);
    }

    public void pausa()
    {
        //pausa el juego
        if (pausar == false)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;
            pausar = true;
        }
        else
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
            pausar = false;
        }
           
    }

    public void ayuda()
    {
        // como entra del pause lo ejecutamos para quitarlo
        pausa();

        //pausa el juego
        if (panelAyudabol == false)
        {
            panelAyuda.SetActive(true);
            Time.timeScale = 0f;
            panelAyudabol = true;
        }
        else
        {
            panelAyuda.SetActive(false);
            Time.timeScale = 1f;
            panelAyudabol = false;
        }

    }

    // metodo que anyade segundo para el time
    public void anyadirSegundo()
    {
        int minutos2 = int.Parse(minutos.text);
        int segundos2 = int.Parse(segundos.text);

        segundos2 ++;
       
        if (segundos2 == 61)
        {

            segundos.text ="00";
            minutos2 ++;
        } else segundos.text = segundos2.ToString("D2");
        minutos.text = minutos2.ToString("D2");
        
    }

    //hace visibles las estrellas en el menu de seleccionar nivel
    public void cargarEstrellasMenu(int lvl, int num)
    {
        if (num == 3)
        {
            switch (lvl)
            {
                case 1:
                    VG.lvl1_1Estrella = true;
                    VG.lvl1_2Estrella = true;
                    VG.lvl1_3Estrella = true;
                    break;
                case 2:
                    VG.lvl2_1Estrella = true;
                    VG.lvl2_2Estrella = true;
                    VG.lvl2_3Estrella = true;
                    break;
                case 3:
                    VG.lvl3_1Estrella = true;
                    VG.lvl3_2Estrella = true;
                    VG.lvl3_3Estrella = true;
                    break;
                case 4:
                    VG.lvl4_1Estrella = true;
                    VG.lvl4_2Estrella = true;
                    VG.lvl4_3Estrella = true;
                    break;
                case 5:
                    VG.lvl5_1Estrella = true;
                    VG.lvl5_2Estrella = true;
                    VG.lvl5_3Estrella = true;
                    break;
                case 6:
                    VG.lvl6_1Estrella = true;
                    VG.lvl6_2Estrella = true;
                    VG.lvl6_3Estrella = true;
                    break;
            }
        }
        else if (num == 2)
        {
            switch (lvl)
            {
                case 1:
                    VG.lvl1_1Estrella = true;
                    VG.lvl1_2Estrella = true;
                    break;
                case 2:
                    VG.lvl2_1Estrella = true;
                    VG.lvl2_2Estrella = true;
                    break;
                case 3:
                    VG.lvl3_1Estrella = true;
                    VG.lvl3_2Estrella = true;
                    break;
                case 4:
                    VG.lvl4_1Estrella = true;
                    VG.lvl4_2Estrella = true;
                    break;
                case 5:
                    VG.lvl5_1Estrella = true;
                    VG.lvl5_2Estrella = true;
                    break;
                case 6:
                    VG.lvl6_1Estrella = true;
                    VG.lvl6_2Estrella = true;
                    break;
            }
        }
        else
        {
            switch (lvl)
            {
                case 1:
                    VG.lvl1_1Estrella = true;
                    break;
                case 2:
                    VG.lvl2_1Estrella = true;
                    break;
                case 3:
                    VG.lvl3_1Estrella = true;
                    break;
                case 4:
                    VG.lvl4_1Estrella = true;
                    break;
                case 5:
                    VG.lvl5_1Estrella = true;
                    break;
                case 6:
                    VG.lvl6_1Estrella = true;
                    break;
            }
        }
    }
    
    public void cargarBoss()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //destruimos los meteoriots
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
            Instantiate(explosion, enemy.transform.localPosition, enemy.transform.rotation);
            SpawnerScript.pararSpawner();
        }
        var rot = transform.rotation;
        rot.y += 180;
        Instantiate(bosss, new Vector3(0, 0, 26.3f), rot);
        PanelVidaBoss.SetActive(true);

        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        Boss bossScript = boss.GetComponent<Boss>();
        maxvidaBoss = bossScript.health;

    }
    // pone vida cuando te hieren y te activa la heridad
    public void PonerVidaBoss(int valor)
    {
        
        float valor2 = (float)valor;

        //si es 0 ganas
        if (valor2 <= 0)
        {
            panelWin.SetActive(true);
            win();
        }

        vidaBoss.fillAmount = valor2 / maxvidaBoss;
        
    }

    public void win()
    {
        GameObject naveGo = GameObject.FindGameObjectWithTag("Player");
        Nave naveScript = naveGo.GetComponent<Nave>();

        if (naveScript.health == maxvida)
        {
            // activamos las estrellas en el panel win 
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            //activamos las variables estaticas
            cargarEstrellasMenu(VG.nivelAct, 3);
        }
        else if (naveScript.health > maxvida / 2)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            cargarEstrellasMenu(VG.nivelAct, 2);
        }
        else
        {
            estrella1.SetActive(true);
            cargarEstrellasMenu(VG.nivelAct, 1);
        }
        
        //Destruimos todo para que no puedan disparar y suene en el menu 
        Destroy(naveGo);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //destruimos los meteoriots
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("2");
            Destroy(enemy);
            Instantiate(explosion, enemy.transform.localPosition, enemy.transform.rotation);
            SpawnerScript.pararSpawner();
        }
        Destroy(GameObject.FindGameObjectWithTag("Boss"));
    }
}
